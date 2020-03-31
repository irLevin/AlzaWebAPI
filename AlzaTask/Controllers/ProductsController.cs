using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Alza.BusinessLogic.Inventory;
using Alza.BusinessLogic.Products;
using Alza.Common.Logger;
using Alza.Common.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlzaTask.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/products")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private IProductsRepo _productsRepo;
        private IInventoryRepo _inventoryRepo;
        private IAlzaLogger _logger;
        private readonly IMapper _mapper;


        public ProductsController(IProductsRepo productsRepo, IInventoryRepo inventoryRepo, IAlzaLogger logger, IMapper mapper)
        {
            _productsRepo = productsRepo;
            _inventoryRepo = inventoryRepo;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of available products.
        /// </summary>
        /// <returns>The list of available products.</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Products not found</response>
        /// <response code="500">Oops! Unexpected error </response>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            IEnumerable<Alza.Common.Entities.Product> products;
            try
            {
                var availableProductId = await _inventoryRepo.GetUnavailableInventoryAsync();
                products = await _productsRepo.GetProductsAsync();
                if (availableProductId.Any())
                {
                    products = products?.Where(p => availableProductId.Contains(p.Id));
                }
                if (products == null)
                {
                    return NotFound();
                }
                
            }
            catch (Exception ex)
            {
                products = new List<Alza.Common.Entities.Product>();
                _logger.LogError("Unexpected error accured in GetProducts", ex);
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return Ok(_mapper.Map<IEnumerable<Product>>(products));
        }

        /// <summary>
        /// Gets the product by id.
        /// </summary>
        /// <returns>The product that match id</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Product not found</response>
        /// <response code="400">Product id has invalid value</response> 
        /// <response code="500">Oops! Unexpected error </response>
        /// <param name="id">product id</param>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Product>> GetProductByID(int id)
        {
            Alza.Common.Entities.Product product;
            try
            {
                if (id > 0)
                {
                    product = await _productsRepo.GetProductByIDAsync(id);
                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                else { return BadRequest(); }
            }
            catch (Exception ex)
            {
                product= new Alza.Common.Entities.Product();
                _logger.LogError("Unexpected error accured in GetProductByID", ex);
            }

            return Ok(_mapper.Map<Product>(product));
        }

        /// <summary>
        /// Update description the provided product.
        /// </summary>
        /// <returns>Success/Failure message</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Product id/description has invalid value</response> 
        /// <response code="500">Oops! Unexpected error </response>
        /// <param name="id">product id</param>
        /// <param name="description">product description</param>
        [HttpPut("{id}/{description}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Product>> UpdateProductDescription (int id, string description)
        {
            bool isUpdated = false;
            try
            {
                if (id > 0 && description.Length > 0)
                {
                    isUpdated = await _productsRepo.UpdateProductDescriptionAsync(id, description);
                }
                else { return BadRequest(); }
            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected error accured in UpdateProductDescription", ex);
            }
            return Content(isUpdated ? "The description of the product has been updated." : "Error in updating the product description");
        }
    }
}

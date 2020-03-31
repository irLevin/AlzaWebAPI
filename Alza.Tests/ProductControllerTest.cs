using Alza.BusinessLogic.Inventory;
using Alza.BusinessLogic.Products;
using Alza.Common.Logger;
using Alza.Common.Models;
using Alza.Data.MockData;
using AlzaTask.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Alza.Tests
{
    public class ProductControllerTest
    {
        private readonly MockDataProvider _mock;
        private readonly ProductsRepo _productRepo;
        private readonly InventoryRepo _inventoryRepo;
        private readonly ConsoleLogger _logger;
        private readonly ProductsController _controller;
        private Mock<IMapper> _mapper;

        public ProductControllerTest()
        {
            _mock = new MockDataProvider();
            _logger = new ConsoleLogger();
            _inventoryRepo = new InventoryRepo(_mock, _logger);
            _productRepo = new ProductsRepo(_mock, _logger, _inventoryRepo);
            _controller = new ProductsController(_productRepo, _inventoryRepo, _logger, SetMapper());
        }

        private IMapper SetMapper()
        {
            _mapper = new Mock<IMapper>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Data.Mapping.Mapper());
            });
            return mockMapper.CreateMapper();
        }
        [Fact]
        public void GetProductsReturnsOkResult()
        {
            var okResult = _controller.GetProducts();
            Assert.IsType<OkObjectResult>(okResult.Result.Result);
        }

        [Fact]
        public void GetProductsReturnsOnlyAvailableItemsCount()
        {
            var okResult = _controller.GetProducts().Result.Result as OkObjectResult;
            var items = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Equal(5, items.Count());
        }

        [Fact]
        public void GetProductByIdUnknownIDPassedNotFoundResult()
        {
            var notFoundResult = _controller.GetProductByID(12345);
            Assert.IsType<NotFoundResult>(notFoundResult.Result.Result);
        }

        [Fact]
        public void GetProductByIdInvalidIDPassedBadRequestResult()
        {
            var badRequestResult = _controller.GetProductByID(-10000);
            Assert.IsType<BadRequestResult>(badRequestResult.Result.Result);
        }

        [Fact]
        public void GetProductByIdReturnsOkResult()
        {
            var okResult = _controller.GetProductByID(100001);
            Assert.IsType<OkObjectResult>(okResult.Result.Result);
        }

        [Fact]
        public void UpdateDescriptionInvalidDescriptionBadRequestResult()
        {
            var badRequestResult = _controller.UpdateProductDescription(100001,"");
            Assert.IsType<BadRequestResult>(badRequestResult.Result.Result);
        }

        [Fact]
        public void UpdateDescriptionContentResult()
        {
            var result = _controller.UpdateProductDescription(100001, "Test Updated description").Result.Result as ContentResult;
            Assert.NotNull(result);
            Assert.Equal("The description of the product has been updated.", result.Content);
        }
    }
}
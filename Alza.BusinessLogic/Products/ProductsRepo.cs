using Alza.BusinessLogic.Inventory;
using Alza.Common.Data;
using Alza.Common.Entities;
using Alza.Common.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alza.BusinessLogic.Products
{
    public class ProductsRepo : IProductsRepo
    {
        private IDataProvider _dataProvider;
        private IAlzaLogger _logger;
        private IInventoryRepo _inventoryRepo;
        public ProductsRepo(IDataProvider dataProvider, IAlzaLogger logger, IInventoryRepo inventoryRepo)
        {
            _dataProvider = dataProvider;
            _logger = logger;
            _inventoryRepo = inventoryRepo;
            logger.Log($"ProductsRepo Initialized, working {dataProvider.GetType().Name}");
        }
        public IEnumerable<Product> GetProducts()
        {
            return _dataProvider.GetProducts();
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            return _dataProvider.GetProductsAsync();
        }

        public Product GetProductByID(int id)
        {
            return _dataProvider.GetProductByID(id);
        }

        public Task<Product> GetProductByIDAsync(int id)
        {
            return _dataProvider.GetProductByIDAsync(id);
        }

        public bool UpdateProductDescription(int id, string description)
        {
            return _dataProvider.UpdateProductDescription(id, description);
        }

        public Task<bool> UpdateProductDescriptionAsync(int id, string description)
        {
            return _dataProvider.UpdateProductDescriptionAsync(id, description);
        }

        public decimal TotalPrice(IEnumerable<Product> products)
        {
            return products.Select(p => p.Price).Sum();
        }
    }
}

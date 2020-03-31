using Alza.Common.Data;
using Alza.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alza.Data.MockData
{
    public class MockDataProvider : IDataProvider
    {
        private static List<Product> products = new List<Product>
        {
            new Product() { Id = 100001, Name = "Product 100001", ImgUrl = "http://img.com/100001.jps", Price = (decimal)20.5, Description = "Product 100001 description" },
            new Product() { Id = 100002, Name = "Product 100002", ImgUrl = "http://img.com/100002.jps", Price = (decimal)12.5, Description = "Product 100002 description" },
            new Product() { Id = 100003, Name = "Product 100003", ImgUrl = "http://img.com/100003.jps", Price = (decimal)10, Description = "Product 100003 description" },
            new Product() { Id = 100004, Name = "Product 100004", ImgUrl = "http://img.com/100004.jps", Price = (decimal)16, Description = "Product 100004 description" },
            new Product() { Id = 100005, Name = "Product 100005", ImgUrl = "http://img.com/100005.jps", Price = (decimal)9.5, Description = "Product 100005 description" },
            new Product() { Id = 100006, Name = "Product 100006", ImgUrl = "http://img.com/100006.jps", Price = (decimal)30, Description = "Product 100006 description" },
            new Product() { Id = 100007, Name = "Product 100007", ImgUrl = "http://img.com/100007.jps", Price = (decimal)40, Description = "Product 100007 description" }
        };
        private static List<Inventory> inventories = new List<Inventory>
        {
            new Inventory() { ProductId = 100001, UnitsInStock = 100 },
            new Inventory() { ProductId = 100002, UnitsInStock = 300 },
            new Inventory() {  ProductId = 100003, UnitsInStock = 5 },
            new Inventory() {  ProductId = 100004, UnitsInStock = 0 },
            new Inventory() {  ProductId = 100005, UnitsInStock = 0 },
            new Inventory() { ProductId = 100006, UnitsInStock = 50 },
            new Inventory() {  ProductId = 100007, UnitsInStock = 100 }
        };
        public IEnumerable<Product> GetProducts()
        {
            return products.Select(p => new Product(p));
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            return Task.FromResult(products.Select(p => new Product(p)));
        }

        public Product GetProductByID(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public Task<Product> GetProductByIDAsync(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }

        public bool UpdateProductDescription(int id, string description)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Description = description;
                return true;
            }
            return false;
        }

        public Task<bool> UpdateProductDescriptionAsync(int id, string description)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Description = description;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public IEnumerable<int> GetUnavailableInventory()
        {
            var availableProductsIds = inventories.Where(num => num.UnitsInStock > 0);
            return availableProductsIds.Select(id => id.ProductId).AsEnumerable<int>();
        }

        public Task<IEnumerable<int>> GetUnavailableInventoryAsync()
        {
            var availableProductsIds = inventories.Where(num => num.UnitsInStock > 0);
            return Task.FromResult(availableProductsIds.Select(id => id.ProductId).AsEnumerable<int>());
        }
    }
}

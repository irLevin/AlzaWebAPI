using Alza.Common.Data;
using Alza.Common.Entities;
using Alza.Data.MSSQLData;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Alza.Data.MockData
{
    public class SQLDataProvider : IDataProvider
    {
        
        private readonly ProductDBContext _context;

        public SQLDataProvider(ProductDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Product.Select(p => new Product(p));
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            return _context.Product.ToListAsync().ContinueWith(p => (IEnumerable<Product>)p.Result);
        }

        public Product GetProductByID(int id)
        {
            return _context.Product.FirstOrDefault(p => p.Id == id);
        }

        public Task<Product> GetProductByIDAsync(int id)
        {
            return _context.Product.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool UpdateProductDescription(int id, string description)
        {
            var product = _context.Product.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Description = description;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public Task<bool> UpdateProductDescriptionAsync(int id, string description)
        {
            var product = _context.Product.FirstOrDefaultAsync(p => p.Id == id).Result;
            if (product != null)
            {
                product.Description = description;
                _context.SaveChangesAsync();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public IEnumerable<int> GetUnavailableInventory()
        {
            var availableProductsIds = _context.Inventory.Where(num => num.UnitsInStock > 0);
            return availableProductsIds.Select(id => id.ProductId).AsEnumerable<int>();
        }

        public Task<IEnumerable<int>> GetUnavailableInventoryAsync()
        {
            var availableProductsIds = (_context.Inventory.Where(num => num.UnitsInStock > 0)?.Select(id => id.ProductId)).ToListAsync();
            return availableProductsIds.ContinueWith(p => (IEnumerable<int>)p.Result);
        }
    }
}

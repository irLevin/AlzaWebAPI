﻿using Alza.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alza.Common.Data
{
    public interface IDataProvider
    {
        IEnumerable<Product> GetProducts();
        Task<IEnumerable<Product>> GetProductsAsync();

        Product GetProductByID(int id);
        Task<Product> GetProductByIDAsync(int id);

        bool UpdateProductDescription(int id, string description);
        Task<bool> UpdateProductDescriptionAsync(int id, string description);

        IEnumerable<int> GetInventoryByProductId(int productId);
        Task<IEnumerable<int>> GetInventoryByProductIdAsync(int productId);
    }
}

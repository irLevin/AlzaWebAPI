using Alza.Common.Data;
using Alza.Common.Logger;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alza.BusinessLogic.Inventory
{
    public class InventoryRepo : IInventoryRepo
    {
        private IDataProvider _dataProvider;
        private IAlzaLogger _logger;

        public InventoryRepo (IDataProvider dataProvider, IAlzaLogger logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
            logger.Log($"InventoryRepo Initialized, working {dataProvider.GetType().Name}");
        }

        public IEnumerable<int> GetInventoryByProductId (int productId)
        {
            return _dataProvider.GetInventoryByProductId(productId);
        }

        public Task<IEnumerable<int>> GetInventoryByProductIdAsync(int productId)
        {
            return _dataProvider.GetInventoryByProductIdAsync(productId);
        }
    }
}

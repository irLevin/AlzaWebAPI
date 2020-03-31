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

        public IEnumerable<int> GetUnavailableInventory()
        {
            return _dataProvider.GetUnavailableInventory();
        }
        public Task<IEnumerable<int>> GetUnavailableInventoryAsync()
        {
            return _dataProvider.GetUnavailableInventoryAsync();
        }
    }
}

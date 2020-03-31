using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alza.BusinessLogic.Inventory
{
    public interface IInventoryRepo
    {
        IEnumerable<int> GetUnavailableInventory();
        Task<IEnumerable<int>> GetUnavailableInventoryAsync();
    }
}

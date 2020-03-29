using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alza.BusinessLogic.Inventory
{
    public interface IInventoryRepo
    {
        IEnumerable<int> GetInventoryByProductId(int productId);
        Task<IEnumerable<int>> GetInventoryByProductIdAsync(int productId);
    }
}

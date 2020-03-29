using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alza.Data.MSSQLData.Models
{
    public class Inventory
    {
        [Key]
        public int ProductId { get; set; }

        public virtual Product OwnedProduct { get; set; }

        public int UnitsInStock { get; set; }
        
    }
}

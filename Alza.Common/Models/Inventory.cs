using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alza.Common.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        [Key]
        public int ProductId { get; set; }
        public int UnitsInStock { get; set; }

    }
}

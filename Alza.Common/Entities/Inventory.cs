using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alza.Common.Entities
{
    public class Inventory
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Id is required")]
        public int ProductId { get; set; }

        public int UnitsInStock { get; set; }

        public Inventory() { }
        public Inventory(Inventory other)
        {
            this.Id = other.Id;
            this.ProductId = other.ProductId;
            this.UnitsInStock = other.UnitsInStock;
        }
    }
}

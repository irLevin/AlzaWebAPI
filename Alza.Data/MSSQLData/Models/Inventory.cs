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
        public int Id { get; set; }

        [Display(Name = "Product")]
        public virtual int ProductId { get; set; }

        [ForeignKey("Id")]
        public virtual Product products { get; set; }
        public int UnitsInStock { get; set; }
        
    }
}

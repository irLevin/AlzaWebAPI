using System.ComponentModel.DataAnnotations;


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

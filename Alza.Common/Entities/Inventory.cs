using System.ComponentModel.DataAnnotations;

namespace Alza.Common.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        [Key]
        public int ProductId { get; set; }

        public virtual Product OwnedProduct { get; set; }

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

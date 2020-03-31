using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Alza.Common.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Name is required")]
        [StringLength(100, ErrorMessage = "The product name should be less 100 characters")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Image URL is required")]
        [StringLength(100, ErrorMessage = "The Image URL should be less 100 characters")]
        public string ImgUrl { get; set; }

        [Required(ErrorMessage = "The product price should be provided")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [StringLength(1000, ErrorMessage = "The product description should be less 1000 characters")]
        public string Description { get; set; }

        public virtual Inventory ProductInventory { get; set; }

        public Product() { }
        public Product(Product other)
        {
            this.Id = other.Id;
            this.Name = other.Name;
            this.ImgUrl = other.ImgUrl;
            this.Price = other.Price;
            this.Description = other.Description;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alza.Common.Entities
{
    public class Product
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "ImgUrl is required")]
        public string ImgUrl { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        public string Description { get; set; }

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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alza.Common.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Name is required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Image URL is required")]
        public string ImgUrl { get; set; }

        [Required(ErrorMessage = "The product price should be provided")]
        public decimal Price { get; set; }

        [StringLength(1000, ErrorMessage = "The product description should be less 1000 characters")]
        public string Description { get; set; }


    }
}

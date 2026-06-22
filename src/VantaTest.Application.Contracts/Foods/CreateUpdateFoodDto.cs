using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VantaTest.Categories;

namespace VantaTest.Foods
{
    public class CreateUpdateFoodDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; } 

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; } 
        [Required]
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}

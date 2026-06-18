using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VantaTest.Categories;

namespace VantaTest.Foods
{
    public class CreateUpdateFoodDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public Category Category { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
    }
}

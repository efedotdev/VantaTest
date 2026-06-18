using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace VantaTest.Categories
{
    public class CreateUpdateCategoryDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; } = string.Empty;
        public Guid? ParentId { get; set; } = Guid.Empty;
        
    }
}

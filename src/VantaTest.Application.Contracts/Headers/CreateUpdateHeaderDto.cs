using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VantaTest.Headers
{
    public class CreateUpdateHeaderDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(256)]
        public string MainHeader { get; set; } 
        [Required]
        [StringLength(512)]
        public string Description { get; set; }
        public string ImagePath { get; set; } = string.Empty;
    }
}

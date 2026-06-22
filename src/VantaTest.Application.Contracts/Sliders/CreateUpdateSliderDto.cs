using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VantaTest.Sliders
{
    public class CreateUpdateSliderDto
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

    }
}

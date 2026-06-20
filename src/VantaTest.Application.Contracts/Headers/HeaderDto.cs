using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Headers
{
    public class HeaderDto : AuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(256)]
        public string MainHeader { get; set; }

        [Required]
        [StringLength(512)]
        public string Description { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}

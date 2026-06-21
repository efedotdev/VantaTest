using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Headers
{
    public class HeaderDto : AuditedEntityDto<Guid>
    {
        public string MainHeader { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}

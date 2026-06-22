using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Sliders
{
    public class SliderDto : AuditedEntityDto<Guid>
    {
        public string ImagePath { get; set; }
        public string Title { get; set; }
    }
}

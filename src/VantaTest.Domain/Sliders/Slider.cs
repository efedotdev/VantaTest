using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace VantaTest.Sliders
{
    public class Slider : AuditedAggregateRoot<Guid>
    {
        public string ImagePath { get; set; }
        public string Title { get; set; }
    }
}

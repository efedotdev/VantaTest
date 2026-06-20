using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace VantaTest.Headers
{
    public class Header : AuditedAggregateRoot<Guid>
    {
        public string MainHeader { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace VantaTest.Categories
{
    public class Category : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public virtual Guid? ParentId { get; set; } = Guid.Empty;
        
        
    }
}

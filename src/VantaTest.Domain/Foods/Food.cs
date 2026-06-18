using System;
using System.Collections.Generic;
using System.Text;
using VantaTest.Categories;
using Volo.Abp.Domain.Entities.Auditing;

namespace VantaTest.Foods
{
    public class Food : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public decimal Price { get; set; }

    }
}

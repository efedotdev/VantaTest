using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Categories
{
    public class CategoryDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; } = Guid.Empty;
    }
}

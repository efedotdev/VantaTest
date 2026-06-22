using System;
using System.Collections.Generic;
using System.Text;
using VantaTest.Categories;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Foods
{
    public class FoodDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }
}

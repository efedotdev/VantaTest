using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VantaTest.Foods
{
    public interface IFoodAppService :
        ICrudAppService<
            FoodDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateFoodDto>
    {
    }
}

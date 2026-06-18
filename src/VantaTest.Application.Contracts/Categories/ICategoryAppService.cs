using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VantaTest.Categories
{
    public interface ICategoryAppService :
        ICrudAppService<
            CategoryDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCategoryDto>
    {
        public Task<PagedResultDto<CategoryDto>> GetAllParent();
    }
}

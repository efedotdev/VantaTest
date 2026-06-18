using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using VantaTest.Foods;
using VantaTest.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using System.Linq;

namespace VantaTest.Categories
{
   // [Authorize(VantaTestPermissions.Categories.Create)]
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly IRepository<Category, Guid> _repository;
        public CategoryAppService(IRepository<Category, Guid> repository)
        {
            _repository = repository;
        }
        //[Authorize(VantaTestPermissions.Categories.Create)]
        public async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
        {
            var category = ObjectMapper.Map<CreateUpdateCategoryDto, Category>(input);
            await _repository.InsertAsync(category);
            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        //[Authorize(VantaTestPermissions.Categories.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        //[AllowAnonymous]
        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var category = await _repository.GetAsync(id);
            return ObjectMapper.Map<Category, CategoryDto>(category);
        }

        //[AllowAnonymous]
        public async Task<PagedResultDto<CategoryDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _repository.GetQueryableAsync();
            var query = queryable
                .Where(c => c.ParentId != null)
                .OrderBy(input.Sorting.IsNullOrWhiteSpace() ? "Name" : input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var categories = await AsyncExecuter.ToListAsync(query);
            var totalCount = await AsyncExecuter.CountAsync(queryable);

            return new PagedResultDto<CategoryDto>(
                totalCount,
                ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories )
            );
        }

        //[Authorize(VantaTestPermissions.Categories.Edit)]
        public async Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input)
        {
            var category = await _repository.GetAsync(id);
            ObjectMapper.Map(input, category);
            await _repository.UpdateAsync(category);
            return ObjectMapper.Map<Category, CategoryDto>(category);
        }
        public async Task<PagedResultDto<CategoryDto>> GetAllParent()
        {
            var queryable = await _repository.GetQueryableAsync();
            var query = queryable.Where(c => c.ParentId == null);
            var categories = await AsyncExecuter.ToListAsync(query);
            var totalCount = await AsyncExecuter.CountAsync(queryable);

            return new PagedResultDto<CategoryDto>(
                totalCount,
                ObjectMapper.Map<List<Category>, List<CategoryDto>>(categories)
            );
        }
    }
}

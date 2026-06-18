using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using VantaTest.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VantaTest.Foods
{
    
    public class FoodAppService : ApplicationService, IFoodAppService
    {
        private readonly IRepository<Food, Guid> _repository;
        public FoodAppService(IRepository<Food, Guid> repository)
        {
            _repository = repository;
        }
        //[Authorize(VantaTestPermissions.Foods.Create)]
        public async Task<FoodDto> CreateAsync(CreateUpdateFoodDto input)
        {
            var food = ObjectMapper.Map<CreateUpdateFoodDto, Food>(input);
            await _repository.InsertAsync(food);
            return ObjectMapper.Map<Food, FoodDto>(food);
        }

       //[Authorize(VantaTestPermissions.Foods.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        //[AllowAnonymous]
        public async Task<FoodDto> GetAsync(Guid id)
        {
            var food = await _repository.GetAsync(id);
            return ObjectMapper.Map<Food, FoodDto>(food);
        }

        public async Task<PagedResultDto<FoodDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _repository.GetQueryableAsync();
            queryable = queryable.Include(x => x.Category);
            var query = queryable
                .OrderBy(input.Sorting.IsNullOrWhiteSpace() ? "Name" : input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var foods = await AsyncExecuter.ToListAsync(query);
            var totalCount = await AsyncExecuter.CountAsync(queryable);

            return new PagedResultDto<FoodDto>(
                totalCount,
                ObjectMapper.Map<List<Food>, List<FoodDto>>(foods)
            );
        }

        //[Authorize(VantaTestPermissions.Foods.Edit)]
        public async Task<FoodDto> UpdateAsync(Guid id, CreateUpdateFoodDto input)
        {
            var food = await _repository.GetAsync(id);
            ObjectMapper.Map(input, food);
            await _repository.UpdateAsync(food);
            return ObjectMapper.Map<Food, FoodDto>(food);
        }       
    }
}

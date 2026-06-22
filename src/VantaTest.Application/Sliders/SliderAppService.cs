using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VantaTest.Headers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using System.Linq;

using System.Linq.Dynamic.Core;

namespace VantaTest.Sliders
{
    public class SliderAppService : ApplicationService, ISliderAppService
    {
        private readonly IRepository<Slider, Guid> _repository;
        public SliderAppService(IRepository<Slider, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<SliderDto> CreateAsync(CreateUpdateSliderDto input)
        {
            var slider = ObjectMapper.Map<CreateUpdateSliderDto, Slider>(input);
            await _repository.InsertAsync(slider);
            return ObjectMapper.Map<Slider, SliderDto>(slider);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<SliderDto> GetAsync(Guid id)
        {
            var slider = await _repository.GetAsync(id);
            return ObjectMapper.Map<Slider, SliderDto>(slider);
        }

        public async Task<PagedResultDto<SliderDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _repository.GetQueryableAsync();
            var query = queryable
                .OrderBy(input.Sorting.IsNullOrWhiteSpace() ? "Title" : input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var sliders = await AsyncExecuter.ToListAsync(query);
            var totalCount = await AsyncExecuter.CountAsync(queryable);

            return new PagedResultDto<SliderDto>(
                totalCount,
                ObjectMapper.Map<List<Slider>, List<SliderDto>>(sliders)
            );
        }

        public async Task<SliderDto> UpdateAsync(Guid id, CreateUpdateSliderDto input)
        {
            var slider = await _repository.GetAsync(id);
            ObjectMapper.Map(input, slider);
            await _repository.UpdateAsync(slider);
            return ObjectMapper.Map<Slider, SliderDto>(slider);
        }
    }
}

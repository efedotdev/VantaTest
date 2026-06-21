using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VantaTest.Foods;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using System.Linq.Dynamic.Core;

namespace VantaTest.Headers
{
    public class HeaderAppService : ApplicationService, IHeaderAppService
    {
        private readonly IRepository<Header, Guid> _repository;
        public HeaderAppService(IRepository<Header, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<HeaderDto> CreateAsync(CreateUpdateHeaderDto input)
        {
            var header = ObjectMapper.Map<CreateUpdateHeaderDto, Header>(input);
            await _repository.InsertAsync(header);
            return ObjectMapper.Map<Header, HeaderDto>(header);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<HeaderDto> GetAsync(Guid id)
        {
            var header = await _repository.GetAsync(id);
            return ObjectMapper.Map<Header, HeaderDto>(header);
        }

        public async Task<PagedResultDto<HeaderDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _repository.GetQueryableAsync();
            var query = queryable
                .OrderBy(input.Sorting.IsNullOrWhiteSpace() ? "MainHeader" : input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var headers = await AsyncExecuter.ToListAsync(query);
            var totalCount = await AsyncExecuter.CountAsync(queryable);

            return new PagedResultDto<HeaderDto>(
                totalCount,
                ObjectMapper.Map<List<Header>, List<HeaderDto>>(headers)
            );
        }

        public async Task<HeaderDto> UpdateAsync(Guid id, CreateUpdateHeaderDto input)
        {
            var header = await _repository.GetAsync(id);
            ObjectMapper.Map(input, header);
            await _repository.UpdateAsync(header);
            return ObjectMapper.Map<Header, HeaderDto>(header);
        }
    }
}

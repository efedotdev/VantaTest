using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VantaTest.Headers
{
    public interface IHeaderAppService :
        ICrudAppService<
        HeaderDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateHeaderDto>
    {
    }
}

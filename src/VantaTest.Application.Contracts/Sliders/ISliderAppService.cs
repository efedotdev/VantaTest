using System;
using System.Collections.Generic;
using System.Text;
using VantaTest.Headers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace VantaTest.Sliders
{
    public interface ISliderAppService :
          ICrudAppService<
        SliderDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateSliderDto>
    {
    }
}

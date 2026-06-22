using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VantaTest.Headers;
using VantaTest.Managers;
using VantaTest.Sliders;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages;

public class IndexModel : VantaTestPageModel
{
    [BindProperty]
    public IReadOnlyList<HeaderDto> Headers { get; set; }
    [BindProperty]
    public IReadOnlyList<SliderDto> Sliders { get; set; }

    protected readonly IHeaderAppService _headerAppService;
    protected readonly ISliderAppService _sliderAppService;

    public IndexModel(IHeaderAppService headerAppService, IFileManager fileManager, ISliderAppService sliderAppService)
    {
        _headerAppService = headerAppService;
        _sliderAppService = sliderAppService;
    }
    public async Task OnGetAsync()
    {
        var resultHeader = await _headerAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        Headers = resultHeader.Items;
        var resultSlider = await _sliderAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        Sliders = resultSlider.Items;
    }
}

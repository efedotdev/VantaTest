using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VantaTest.Headers;
using VantaTest.Managers;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages;

public class IndexModel : VantaTestPageModel
{
    [BindProperty]
    public IReadOnlyList<HeaderDto> Headers { get; set; }

    protected readonly IHeaderAppService _headerAppService;

    public IndexModel(IHeaderAppService headerAppService, IFileManager fileManager)
    {
        _headerAppService = headerAppService;
    }
    public async Task OnGetAsync()
    {
        var resultHeader = await _headerAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        Headers = resultHeader.Items;
    }
}

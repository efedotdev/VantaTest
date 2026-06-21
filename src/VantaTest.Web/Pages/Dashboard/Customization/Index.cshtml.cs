using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VantaTest.Headers;
using VantaTest.Managers;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages.Dashboard.Customization
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IReadOnlyList<HeaderDto> Headers { get; set; }

        protected readonly IHeaderAppService _headerAppService;
        protected readonly IFileManager _fileManager;

        public IndexModel(IHeaderAppService headerAppService,IFileManager fileManager)
        {
            _headerAppService = headerAppService;
            _fileManager = fileManager;
        }
        public async Task OnGetAsync()
        {
            var resultHeader = await _headerAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            Headers = resultHeader.Items;
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var header = await _headerAppService.GetAsync(id);
            await _fileManager.DeleteImagePath(header.ImagePath);
            await _headerAppService.DeleteAsync(id);
            return RedirectToPage();
        }

    }
}
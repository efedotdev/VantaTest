using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VantaTest.Categories;
using VantaTest.Foods;
using VantaTest.Headers;
using VantaTest.Managers;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages.Dashboard.Customization
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateUpdateHeaderDto Header { get; set; }
        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public IReadOnlyList<HeaderDto> Headers { get; set; }

        protected readonly IHeaderAppService _headerAppService;
        protected readonly IFileManager _FileManager;

        public CreateModel(IHeaderAppService headerAppService, IFileManager fileManager)
        {
            _headerAppService = headerAppService;
            _FileManager = fileManager;
        }

        public async Task OnGetAsync()
        {
            var resultHeaders = await _headerAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            Headers = resultHeaders.Items;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }
            var newPath = _FileManager.CreateImagePath(UploadedImage, "headers");
            Header.ImagePath = newPath.Result;
            await _headerAppService.CreateAsync(Header);
            return RedirectToPage("./Index");
        }
    }
}

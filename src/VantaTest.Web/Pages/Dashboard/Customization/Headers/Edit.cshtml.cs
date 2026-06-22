using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VantaTest.Categories;
using VantaTest.Foods;
using VantaTest.Headers;
using VantaTest.Managers;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages.Dashboard.Customization.Headers
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public CreateUpdateHeaderDto Header { get; set; }

        public IReadOnlyList<HeaderDto> Headers { get; set; }
        public IFormFile? UploadedImage { get; set; }

        protected readonly IHeaderAppService _headerAppService;

        protected readonly IFileManager _fileManager;
        public EditModel(IHeaderAppService headerAppService, IFileManager fileManager)
        {
            _headerAppService = headerAppService;
            _fileManager = fileManager;

        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var headerDto = await _headerAppService.GetAsync(id);
            if (headerDto == null)
            {
                return RedirectToPage("./Index");
            }

            Header = new CreateUpdateHeaderDto
            {
                MainHeader = headerDto.MainHeader,
                Description = headerDto.Description,
                ImagePath = headerDto.ImagePath
            };
            var resultHeaders = await _headerAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            Headers = resultHeaders.Items;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                var resultHeaders = await _headerAppService.GetListAsync(new PagedAndSortedResultRequestDto());
                Headers = resultHeaders.Items;
                return Page();
            }
            if (UploadedImage != null && UploadedImage.Length > 0)
            {  
                var newPath = await _fileManager.UpdateImagePath(UploadedImage, Header.ImagePath);
                Header.ImagePath = newPath;
            }
            await _headerAppService.UpdateAsync(id, Header);
            return RedirectToPage("./Index");
        }
    }
}

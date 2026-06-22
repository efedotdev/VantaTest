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
using VantaTest.Sliders;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages.Dashboard.Customization.Sliders
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public CreateUpdateSliderDto Slider { get; set; }

        public IReadOnlyList<SliderDto> Sliders { get; set; }
        public IFormFile? UploadedImage { get; set; }

        protected readonly ISliderAppService _sliderAppService;

        protected readonly IFileManager _fileManager;
        public EditModel(ISliderAppService SliderAppService, IFileManager fileManager)
        {
            _sliderAppService = SliderAppService;
            _fileManager = fileManager;

        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var sliderDto = await _sliderAppService.GetAsync(id);
            if (sliderDto == null)
            {
                return RedirectToPage("./Index");
            }

            Slider = new CreateUpdateSliderDto
            {
                Title = sliderDto.Title,
                ImagePath = sliderDto.ImagePath
            };
            var resultHeaders = await _sliderAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            Sliders = resultHeaders.Items;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                var resultHeaders = await _sliderAppService.GetListAsync(new PagedAndSortedResultRequestDto());
                Sliders = resultHeaders.Items;
                return Page();
            }
            if (UploadedImage != null && UploadedImage.Length > 0)
            {  
                var newPath = await _fileManager.UpdateImagePath(UploadedImage, Slider.ImagePath);
                Slider.ImagePath = newPath;
            }
            await _sliderAppService.UpdateAsync(id, Slider);
            return RedirectToPage("./Index");
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VantaTest.Managers;
using VantaTest.Sliders;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages.Dashboard.Customization.Sliders
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateUpdateSliderDto Slider { get; set; }
        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public IReadOnlyList<SliderDto> Sliders { get; set; }

        protected readonly ISliderAppService _sliderAppService;
        protected readonly IFileManager _fileManager;

        public CreateModel(ISliderAppService sliderAppService, IFileManager fileManager)
        {
            _sliderAppService = sliderAppService;
            _fileManager = fileManager;
        }

        public async Task OnGetAsync()
        {
            var resultSliders = await _sliderAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            Sliders = resultSliders.Items;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }
            var newPath = await _fileManager.CreateImagePath(UploadedImage, "sliders");
            Slider.ImagePath = newPath;
            await _sliderAppService.CreateAsync(Slider);
            return RedirectToPage("./Index");
        }
    }
}

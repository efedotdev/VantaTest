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
using VantaTest.Sliders;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages.Dashboard.Customization.Sliders
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IReadOnlyList<SliderDto> Sliders { get; set; }

        protected readonly ISliderAppService _sliderAppService;    
        protected readonly IFileManager _fileManager;

        public IndexModel(ISliderAppService sliderAppService,IFileManager fileManager)
        {
            _sliderAppService = sliderAppService;
            _fileManager = fileManager;
        }
        public async Task OnGetAsync()
        {
            var resultSlider = await _sliderAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            Sliders = resultSlider.Items;
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var slider = await _sliderAppService.GetAsync(id);
            await _fileManager.DeleteImagePath(slider.ImagePath);
            await _sliderAppService.DeleteAsync(id);
            return RedirectToPage();
        }

    }
}
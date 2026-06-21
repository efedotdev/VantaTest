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
using VantaTest.Managers;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages.Dashboard.Foods
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateUpdateFoodDto Food { get; set; }
        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        public IReadOnlyList<CategoryDto> Categories { get; set; }

        protected readonly IFoodAppService _foodAppService;
        protected readonly ICategoryAppService _categoryAppService;
        protected readonly IFileManager _fileManager;

        public CreateModel(IFoodAppService foodAppService, ICategoryAppService categoryAppService, IFileManager fileManager)
        {
            _foodAppService = foodAppService;
            _categoryAppService = categoryAppService;
            _fileManager = fileManager;
        }

        public async Task OnGetAsync()
        {
            var resultCategory = await _categoryAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            Categories = resultCategory.Items;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            var newPath = await _fileManager.CreateImagePath(UploadedImage, "foods");
            Food.ImagePath = newPath;
            await _foodAppService.CreateAsync(Food);
            return RedirectToPage("./Index");
        }
    }
}

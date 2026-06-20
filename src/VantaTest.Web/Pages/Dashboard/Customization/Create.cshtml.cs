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
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages.Dashboard.Customization
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
        private readonly IWebHostEnvironment _env;

        public CreateModel(IFoodAppService foodAppService, ICategoryAppService categoryAppService, IWebHostEnvironment env)
        {
            _foodAppService = foodAppService;
            _categoryAppService = categoryAppService;
            _env = env;
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

            if (UploadedImage != null && UploadedImage.Length > 0)
            {
                var extension = Path.GetExtension(UploadedImage.FileName);
                var newFileName = Guid.NewGuid().ToString() + extension;
                var folderPath = Path.Combine(_env.WebRootPath, "images", "foods");
                var exactFilePath = Path.Combine(folderPath, newFileName);
                using (var stream = new FileStream(exactFilePath, FileMode.Create))
                {
                    await UploadedImage.CopyToAsync(stream);
                }
                Food.ImagePath = "/images/foods/" + newFileName;
            }
            await _foodAppService.CreateAsync(Food);
            return RedirectToPage("./Index");
        }
    }
}

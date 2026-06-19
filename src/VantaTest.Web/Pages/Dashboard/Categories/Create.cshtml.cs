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

namespace VantaTest.Web.Pages.Dashboard.Categories
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateUpdateCategoryDto Category { get; set; }
        public IReadOnlyList<CategoryDto> Categories { get; set; }
        public IReadOnlyList<CategoryDto> ParentCategories { get; set; }

        protected readonly IFoodAppService _foodAppService;
        protected readonly ICategoryAppService _categoryAppService;

        public CreateModel(IFoodAppService foodAppService, ICategoryAppService categoryAppService)
        {
            _foodAppService = foodAppService;
            _categoryAppService = categoryAppService;
        }

        public async Task OnGetAsync()
        {
            var resultCategory = await _categoryAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            Categories = resultCategory.Items;
            var resultParentCategory = await _categoryAppService.GetAllParent();
            ParentCategories = resultParentCategory.Items;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }
            await _categoryAppService.CreateAsync(Category);
            return RedirectToPage("./Index");
        }
    }
}

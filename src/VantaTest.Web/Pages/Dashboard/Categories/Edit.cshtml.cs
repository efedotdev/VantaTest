using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VantaTest.Categories;
using VantaTest.Foods;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages.Dashboard.Categories
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public CreateUpdateCategoryDto Category { get; set; }

        public IReadOnlyList<CategoryDto> Categories { get; set; }
        public IReadOnlyList<CategoryDto> ParentCategories { get; set; }

        protected readonly IFoodAppService _foodAppService;
        protected readonly ICategoryAppService _categoryAppService;

        public EditModel(IFoodAppService foodAppService, ICategoryAppService categoryAppService)
        {
            _foodAppService = foodAppService;
            _categoryAppService = categoryAppService;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var categoryDto = await _categoryAppService.GetAsync(id);
            if (categoryDto == null)
            {
                return RedirectToPage("./Index");
            }
            Category = new CreateUpdateCategoryDto
            {
                Name = categoryDto.Name,
                ParentId = categoryDto.ParentId,
            };
            var resultCategory = await _categoryAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            Categories = resultCategory.Items;
            var resultParentCategory = await _categoryAppService.GetAllParent();
            ParentCategories = resultParentCategory.Items;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (!ModelState.IsValid)
            {
                var resultCategory = await _categoryAppService.GetListAsync(new PagedAndSortedResultRequestDto());
                Categories = resultCategory.Items;
                return Page();
            }
            await _categoryAppService.UpdateAsync(id, Category);
            return RedirectToPage("./Index");
        }
    }
}

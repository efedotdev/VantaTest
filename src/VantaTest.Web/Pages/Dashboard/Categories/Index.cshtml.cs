using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VantaTest.Categories;
using VantaTest.Foods;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages.Dashbord.Categories
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IReadOnlyList<CategoryDto> Categories { get; set; }
        public IReadOnlyList<CategoryDto> ParentCategories { get; set; }
        
        protected readonly ICategoryAppService _categoryAppService;
        public IndexModel(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        public async Task OnGetAsync()
        {
            var resultCategory = await _categoryAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            Categories = resultCategory.Items;
            var resultParentCategory = await _categoryAppService.GetAllParent();
            ParentCategories = resultParentCategory.Items;

        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            await _categoryAppService.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}

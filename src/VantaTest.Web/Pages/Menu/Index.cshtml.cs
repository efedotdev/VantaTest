using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VantaTest.Categories;
using VantaTest.Foods;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectMapping;

namespace VantaTest.Web.Pages.Menu
{
    public class IndexModel : VantaTestPageModel
    {
        [BindProperty]
        public IReadOnlyList<CategoryDto> ParentCategories { get; set; }

        [BindProperty]

        public IReadOnlyList<CategoryDto> Categories { get; set; }

        private readonly ICategoryAppService _categoryAppService;
        public IndexModel( ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        public async Task OnGetAsync()
        {
            var resultParentCategory = await _categoryAppService.GetAllParent();
            var resultCategory = await _categoryAppService.GetListAsync(new PagedAndSortedResultRequestDto());

            ParentCategories = resultParentCategory.Items;
            Categories = resultCategory.Items;
        }
    }
}

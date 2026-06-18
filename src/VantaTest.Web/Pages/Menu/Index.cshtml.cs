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
        public IReadOnlyList<FoodDto> Foods { get; set; }
        [BindProperty]

        public IReadOnlyList<CategoryDto> Categories { get; set; }

        private readonly IFoodAppService _foodAppService;
        private readonly ICategoryAppService _categoryAppService;
        public IndexModel(IFoodAppService foodAppService, ICategoryAppService categoryAppService)
        {
            _foodAppService = foodAppService;
            _categoryAppService = categoryAppService;
        }
        public async Task OnGetAsync()
        {
            var resultFood = await _foodAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            var resultCategory = await _categoryAppService.GetListAsync(new PagedAndSortedResultRequestDto());

            Foods = resultFood.Items;
            Categories = resultCategory.Items;
        }
    }
}

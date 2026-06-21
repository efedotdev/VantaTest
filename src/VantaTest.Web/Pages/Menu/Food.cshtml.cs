using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VantaTest.Foods;

namespace VantaTest.Web.Pages.Menu
{
    public class FoodModel : PageModel
    {
        private readonly IFoodAppService _foodAppService;

        public IReadOnlyList<FoodDto> FoodItems { get; set; }

        public FoodModel(IFoodAppService foodAppService)
        {
            _foodAppService = foodAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var foodsByCategory = await _foodAppService.GetFoodsByCategoryIdAsync(id);
            FoodItems = foodsByCategory.Items;
        }
    }
}

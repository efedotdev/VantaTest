using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VantaTest.Categories;
using VantaTest.Foods;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages.Dashbord.Customization
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IReadOnlyList<FoodDto> Foods { get; set; }
        
        protected readonly IFoodAppService _foodAppService;
        public IndexModel(IFoodAppService foodAppService)
        {
            _foodAppService = foodAppService;
        }
        public async Task OnGetAsync()
        {
            var resultFood = await _foodAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            Foods = resultFood.Items;
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            await _foodAppService.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}

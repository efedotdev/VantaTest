using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VantaTest.Categories;
using VantaTest.Foods;
using VantaTest.Managers;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages.Dashbord
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IReadOnlyList<FoodDto> Foods { get; set; }
        
        protected readonly IFoodAppService _foodAppService;
        protected readonly IFileManager _fileManager;
        public IndexModel(IFoodAppService foodAppService,IFileManager fileManager)
        {
            _foodAppService = foodAppService;
            _fileManager = fileManager;
        }
        public async Task OnGetAsync()
        {
            var resultFood = await _foodAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            Foods = resultFood.Items;
        }
        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var food = await _foodAppService.GetAsync(id);
            await _fileManager.DeleteImagePath(food.ImagePath);
            await _foodAppService.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}

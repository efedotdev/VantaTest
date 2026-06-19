using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VantaTest.Categories;
using VantaTest.Foods;
using Volo.Abp.Application.Dtos;

namespace VantaTest.Web.Pages.Dashboard.Foods
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public CreateUpdateFoodDto Food { get; set; }

        public IReadOnlyList<CategoryDto> Categories { get; set; }

        protected readonly IFoodAppService _foodAppService;
        protected readonly ICategoryAppService _categoryAppService;

        public EditModel(IFoodAppService foodAppService, ICategoryAppService categoryAppService)
        {
            _foodAppService = foodAppService;
            _categoryAppService = categoryAppService;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var foodDto = await _foodAppService.GetAsync(id);
            if (foodDto == null)
            {
                return RedirectToPage("./Index");
            }
            Food = new CreateUpdateFoodDto
            {
                Name = foodDto.Name,
                Description = foodDto.Description,
                Price = foodDto.Price,
                CategoryId = foodDto.Category != null ? foodDto.Category.Id : Guid.Empty
            };
            var resultCategory = await _categoryAppService.GetListAsync(new PagedAndSortedResultRequestDto());
            Categories = resultCategory.Items;

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
            await _foodAppService.UpdateAsync(id, Food);
            return RedirectToPage("./Index");
        }
    }
}

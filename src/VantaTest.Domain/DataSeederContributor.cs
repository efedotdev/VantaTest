using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VantaTest.Categories;
using VantaTest.Foods;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace VantaTest
{
    public class DataSeederContributor
    : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Food, Guid> _foodRepository;
        private readonly IRepository<Category, Guid> _categoryRepository;
        

        public DataSeederContributor(IRepository<Food, Guid> foodRepository, IRepository<Category, Guid> categoryRepository, IGuidGenerator guidGenerator)
        {
            _foodRepository = foodRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
          
            await _categoryRepository.InsertAsync(
                    new Category
                    {
                       
                        Name = "Burgerler",
                        ParentId  = Guid.Parse("1f06ac7b-6aa5-1d20-0142-3a21ed219820")

                    },
                    autoSave: true
             );

                await _categoryRepository.InsertAsync(
                    new Category
                    {
                        
                        Name = "Şaraplar",
                        ParentId = Guid.Parse("b988b242-753d-f186-7be1-3a21ed2198f1")

                    },
                    autoSave: true
                );
                await _categoryRepository.InsertAsync(
                    new Category
                    {
                        
                        Name = "Gazlı İçecekler",
                        ParentId = Guid.Parse("5d9e4a6e-f338-4f33-6523-3a21ed2198f3")

                    },
                    autoSave: true
                );
            
        }
        //public async Task SeedAsync(DataSeedContext context)
        //{
        //    var category = await _categoryRepository.FirstOrDefaultAsync(c => c.Name == "Ara Sıcaklar");
        //    if (await _foodRepository.GetCountAsync() <= 0)
        //    {
        //        await _foodRepository.InsertAsync(
        //            new Food
        //            {
        //                Name = "Sarma",
        //                CategoryId = category.Id,
        //                Description = "A traditional dish made of minced meat, rice, and spices wrapped in cabbage leaves.",
        //                Price = 150
        //            },
        //            autoSave: true
        //        );

        //        await _foodRepository.InsertAsync(
        //            new Food
        //            {
        //                Name = "Makarna",
        //                CategoryId = category.Id,
        //                Description = "A popular pasta dish made with macaroni and cheese.",
        //                Price = 120
        //            },
        //            autoSave: true
        //        );
        //    }
        //}
    }
}

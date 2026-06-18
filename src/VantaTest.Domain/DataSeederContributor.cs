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
                       
                        Name = "Yiyecekler",
                        ParentId  =null

                    },
                    autoSave: true
             );

                await _categoryRepository.InsertAsync(
                    new Category
                    {
                        
                        Name = "Alkollü İçecekler",
                        ParentId = null

                    },
                    autoSave: true
                );
                await _categoryRepository.InsertAsync(
                    new Category
                    {
                        
                        Name = "Alkollsüz İçecekler",
                        ParentId = null

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

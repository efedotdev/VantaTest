using Riok.Mapperly.Abstractions;
using VantaTest.Categories;
using VantaTest.Foods;
using Volo.Abp.Mapperly;

namespace VantaTest;


[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class VantaTestFoodtoFoodDtoMappers : MapperBase<Food, FoodDto>
{
    public override partial FoodDto Map(Food source);
    public override partial void Map(Food source, FoodDto destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class VantaCreateUpdateFoodDtoToFoodMappers : MapperBase<CreateUpdateFoodDto, Food>
{
    public override partial Food Map(CreateUpdateFoodDto source);
    public override partial void Map(CreateUpdateFoodDto source, Food destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class VantaTestCategoryToCategoryDtoMappers : MapperBase<Category, CategoryDto>
{
    public override partial CategoryDto Map(Category source);
    public override partial void Map(Category source, CategoryDto destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class VantaCreateUpdateCategoryDtoToCategoryMappers : MapperBase<CreateUpdateCategoryDto, Category>
{
    public override partial Category Map(CreateUpdateCategoryDto source);
    public override partial void Map(CreateUpdateCategoryDto source, Category destination);
}

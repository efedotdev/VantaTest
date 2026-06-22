using Riok.Mapperly.Abstractions;
using VantaTest.Categories;
using VantaTest.Foods;
using VantaTest.Headers;
using VantaTest.Sliders;
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
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class VantaTestHeaderToHeaderDtoMappers : MapperBase<Header, HeaderDto>
{
    public override partial HeaderDto Map(Header source);
    public override partial void Map(Header source, HeaderDto destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class VantaCreateUpdateHeaderDtoToHeaderMappers : MapperBase<CreateUpdateHeaderDto, Header>
{
    public override partial Header Map(CreateUpdateHeaderDto source);
    public override partial void Map(CreateUpdateHeaderDto source, Header destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class VantaTestSliderToSliderDtoMappers : MapperBase<Slider, SliderDto>
{
    public override partial SliderDto Map(Slider source);
    public override partial void Map(Slider source, SliderDto destination);
}
[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class VantaCreateUpdateSliderDtoToSliderMappers : MapperBase<CreateUpdateSliderDto, Slider>
{
    public override partial Slider Map(CreateUpdateSliderDto source);
    public override partial void Map(CreateUpdateSliderDto source, Slider destination);
}

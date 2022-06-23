using AutoMapper;
using Entities.Concrete;
using Entities.Concrete.Dtos;


namespace Business.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
            CreateMap<ProductAddDto, Product>().ReverseMap();

            CreateMap<CategoryAddDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}

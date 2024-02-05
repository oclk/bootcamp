using AutoMapper;
using BootcampAPI.DTOs;
using BootcampAPI.Entities;

namespace BootcampAPI.Mappings;

public class DtoProfile : Profile
{
    public DtoProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductAddDtoRequest, Product>();
        CreateMap<ProductUpdateDtoRequest, Product>();

        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryAddDtoRequest, Category>();
        CreateMap<CategoryAddWithProductsDtoRequest, Category>();
        CreateMap<CategoryUpdateDtoRequest, Category>();
    }
}

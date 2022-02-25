using AutoMapper;
using Domain.Models;
using Domain.Dto.Categories;

namespace Application.Profiles;

public class ProfileCategory: Profile{
    public ProfileCategory(){
        CreateMap<CategoriesDto, Category>();
        CreateMap<Category,CategoriesDto>();
        CreateMap<Category,CategoryDetailsDto>()
        .ForMember(dest=> dest.Products,
        opt=> opt.MapFrom(src=> src.Products));
        CreateMap<CategoryDetailsDto,Category>();
    }
}
using AutoMapper;
using Domain.Dto.Products;
using Domain.Models;

namespace Application.Profiles;

public class ProfileProduct: Profile{
    public ProfileProduct(){
        CreateMap<Product,ProductDto>();
        CreateMap<ProductDto,Product>();
        CreateMap<ProductDetailsDto,Product>();
        CreateMap<Product,ProductDetailsDto>()
        .ForMember(dest=>dest.Category,
        opt=>opt.MapFrom(src=>src.Category)); 
        CreateMap<ProductCategoryDto,Product>();
        CreateMap<Product,ProductCategoryDto>();
    }
    
}


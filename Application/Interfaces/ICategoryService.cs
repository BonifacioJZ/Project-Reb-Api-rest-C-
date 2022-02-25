using Domain.Dto.Categories;
using Domain.Models;

namespace Application.Interfaces;

public interface ICategoryService{
    Task<ICollection<CategoriesDto>> GetAll();
    Task<CategoryDetailsDto> GetByCategory(Guid categoryId);
    Task<CategoriesDto> Create(CategoriesDto category);
    Task<CategoriesDto> Update(CategoriesDto category, Guid categoryId);
    Task <int> Delete(Guid categoryId);
}
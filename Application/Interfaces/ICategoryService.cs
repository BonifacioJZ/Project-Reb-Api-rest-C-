using Domain.Dto.Categories;
using Domain.Models;

namespace Application.Interfaces;

public interface ICategoryService{
    Task<ICollection<Category>> GetAll();
    Task<CategoriesDto> GetByCategory(Guid categoryId);
    Task<Category> Create(NewCategoryDto category);
    Task<CategoriesDto> Update(CategoriesDto category, Guid categoryId);
    Task <int> Delete(Guid categoryId);
}
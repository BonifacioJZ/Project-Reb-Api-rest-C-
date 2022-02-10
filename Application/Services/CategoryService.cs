using Application.Interfaces;
using Domain.Dto.Categories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly RebContext _context;

    public CategoryService(RebContext context){
        _context = context;
    }
   

    public async Task<Category?> Create(NewCategoryDto category)
    {
        Category New_Category = new(
            category.Name,
            category.Description);
        _context.Categories.Add(New_Category);
        var result = await _context.SaveChangesAsync();
        if(result == 0) return null;
        return New_Category;
    }

    public Task<int> Delete(Guid categoryId)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Category>> GetAll()=> await _context.Categories.ToListAsync(); 

    public async Task<CategoriesDto?> GetByCategory(Guid categoryId)
    {
        var category = await _context.Categories.FindAsync(categoryId);
        if (category == null)
            return null;
        CategoriesDto categoryDto = new ();
        categoryDto.Id = category.Id;
        categoryDto.Name = category.Name;
        categoryDto.Description = category.Description;
        return categoryDto;
        
    }

    public Task<CategoriesDto> Update(CategoriesDto category, Guid categoryId)
    {
        throw new NotImplementedException();
    }
}

using Application.Interfaces;
using Domain.Dto.Categories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using AutoMapper;
namespace Application.Services;

public class CategoryService : ICategoryService
{
    private readonly RebContext _context;
    private readonly IMapper _mapper;

    public CategoryService(RebContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoriesDto> Create(CategoriesDto category)
    {
        category.Id = Guid.NewGuid();
        var New_Category = _mapper.Map<Category>(category);
        _context.Categories.Add(New_Category);
        var result = await _context.SaveChangesAsync();
        if(result == 0) throw new Exception("Error in to create category");
        
        return category;
    }

    public async Task<int> Delete(Guid categoryId){
        var category = await _context.Categories.FindAsync(categoryId);
        if (category == null) throw new Exception("Error in to find the category with id " + categoryId);
        _context.Categories.Remove(category);
        var result = await _context.SaveChangesAsync();
        if(result == 0) throw new Exception("Error in to delete category");
        return result;
    }

    public async Task<ICollection<CategoriesDto>> GetAll(){
        var categoriesDto = _mapper.Map<ICollection<CategoriesDto>>(await _context.Categories.ToListAsync());
        return categoriesDto;
    } 
    

    public async Task<CategoryDetailsDto> GetByCategory(Guid categoryId)
    {
        var category = await _context.Categories
        .Where(c => c.Id == categoryId)
        .Include(c => c.Products).FirstOrDefaultAsync();   
        var categoryDto = _mapper.Map<CategoryDetailsDto>(category);
        return categoryDto;
        
    }

    public async Task<CategoriesDto> Update(CategoriesDto category, Guid categoryId)
    {
        var actualCategory = await _context.Categories.FindAsync(categoryId);
        if(actualCategory==null) throw new ArgumentException("Error in to find to category with id " + categoryId);

        actualCategory.Name = category.Name?? actualCategory.Name;
        actualCategory.Description = category.Description ?? actualCategory.Description;
        var result = await _context.SaveChangesAsync();
        if(result == 0)
            throw new ArgumentException("Error in  to save the category");
        
        return category;
    }
}

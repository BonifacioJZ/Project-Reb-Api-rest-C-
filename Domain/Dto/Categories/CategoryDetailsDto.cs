using Domain.Models;
using Domain.Dto.Products;
namespace Domain.Dto.Categories;

public class CategoryDetailsDto{
    public Guid Id { get; set; }
    public string Name { get; set; } = "Category";
    public string Description { get; set; } = "Category";
    public ICollection<ProductCategoryDto>? Products {get; set; }
}

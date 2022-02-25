using Domain.Dto.Categories;
namespace Domain.Dto.Products;


public class ProductDetailsDto{
    public Guid Id { get; set; }
    public string Name { get; set;} = "Service";
    public string Description { get; set; } = "Service";

    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }

    public CategoriesDto? Category { get; set; }
}

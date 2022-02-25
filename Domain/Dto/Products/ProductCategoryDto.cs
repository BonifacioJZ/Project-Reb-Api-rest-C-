namespace Domain.Dto.Products;

public class ProductCategoryDto{
    public Guid Id { get; set; }
    public string Name { get; set;} = "Service";
    public string Description { get; set; } = "Service";

    public Decimal Price { get; set; }
}

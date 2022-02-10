namespace Domain.Dto.Products;

public class ProductDto{
    public Guid Id { get; set; }
    public string Name { get; set;} = "Service";
    public string Description { get; set; } = "Service";

    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}

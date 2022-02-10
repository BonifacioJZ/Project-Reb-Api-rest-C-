using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models;



public class Product
{

    
    public Product( string name, string description, Decimal price, Guid categoryId)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.CategoryId = categoryId;

    }
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = "Name";
    public string Description { get; set; } = "Description";
    public Decimal Price { get; set; }
    public Guid CategoryId { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Category? Category { get; set; }

}
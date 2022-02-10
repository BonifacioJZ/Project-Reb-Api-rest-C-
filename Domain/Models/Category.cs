using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Category
{

    public Category( string name, string description)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.Description = description;

    }
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = "name";
    public string Description { get; set; } = "Description";
    public ICollection<Product>? Products { get; set; }
}
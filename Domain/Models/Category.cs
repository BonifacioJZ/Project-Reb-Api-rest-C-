using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Category
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = "name";
    public string Description { get; set; } = "Description";
    public ICollection<Product>? Products { get; set; }
}
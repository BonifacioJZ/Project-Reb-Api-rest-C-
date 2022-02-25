namespace Domain.Models;

public class Client{ 
    public Guid ClientId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly BirthDay { get; set; }
    public string PhoneNumber { get; set; }
}
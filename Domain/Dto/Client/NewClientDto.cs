namespace Domain.Dto.Client;

public class NewClientDto{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDay { get; set; }
    public string PhoneNumber { get; set; }
}
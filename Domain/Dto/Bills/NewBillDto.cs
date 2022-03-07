namespace Domain.Dto.Bills;

public class NewBillsDto{
    public Decimal Total { get; set; }
    public DateTime Date { get; set; }
    public Guid ClientId { get; set; }
}
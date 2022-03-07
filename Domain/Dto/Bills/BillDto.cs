namespace Domain.Dto.Bills;

public class BillDto{
    public Guid BillId { get; set; }
    public Decimal Total { get; set; }
    public DateTime Date { get; set; }
    public Guid ClientId { get; set; }
}
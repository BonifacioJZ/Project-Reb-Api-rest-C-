namespace Domain.Models;

public class Bill{
    public Guid BillId { get; set; }
    public Decimal Total { get; set; }
    public DateTime Date { get; set; }
    public Guid ClientId { get; set; }
    public virtual Client? Client { get; set; }
    public virtual ICollection<DetailsBill>? DetailsBills { get; set; }


}
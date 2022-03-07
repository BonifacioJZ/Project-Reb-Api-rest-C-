namespace Domain.Models;

public class DetailsBill{
    public Guid DetailBillId { get; set; }
    public int Qta { get; set; }
    public Guid BillId { get; set; }
    public virtual Bill Bill { get; set; }
    public Decimal ProductPrice { get; set; }
    public Decimal SubTotal { get; set; }
}
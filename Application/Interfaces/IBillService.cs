using Domain.Dto.Bills;
namespace Application.Interfaces;

public interface IBillService{
    public Task<ICollection<BillDto>> GetAll();
    public Task<BillDto> GetById(Guid id);
    public Task<BillDto> New(NewBillsDto billsDto);
    public Task<BillDto> Update(BillDto billDto,Guid id);
    public Task<int> Delete(Guid id);
}
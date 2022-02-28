using Domain.Dto.Client;
namespace Application.Interfaces;

public interface IClientService{
    Task<ICollection<ClientDto>> GetAll();
    Task<ClientDto> GetById(Guid clientId);
    Task<ClientDto> New(ClientDto clientDto);
    Task<ClientDto> Update(ClientDto clientDto, Guid id);
    Task<int> Delete(Guid clientId);


}
using Application.Interfaces;
using AutoMapper;
using Domain.Dto.Client;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Services;
public class ClientService : IClientService
{
    private readonly IMapper _mapper;
    private readonly RebContext _context;
    public ClientService(IMapper mapper, RebContext context){
        _mapper = mapper;
        _context = context;
    }

    public Task<int> Delete(Guid clientId)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<ClientDto>> GetAll()
    {
        var client_dto = _mapper.Map<ICollection<ClientDto>>(await _context.Clients.ToListAsync());
        return client_dto;
    }

    public async Task<ClientDto> GetById(Guid clientId)
    {
        var client = _mapper.Map<ClientDto>(await _context.Clients.FindAsync(clientId));
        return client;
    }

    public Task<ClientDto> New(NewClientDto clientDto)
    {
        throw new NotImplementedException();
    }

    public Task<ClientDto> Update(ClientDto clientDto)
    {
        throw new NotImplementedException();
    }
}
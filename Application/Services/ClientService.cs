using Application.Interfaces;
using AutoMapper;
using Domain.Dto.Client;
using Domain.Models;
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

    public async Task<int> Delete(Guid clientId)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client == null) throw new ArgumentException("No Found client with id "+ clientId);
        _context.Clients.Remove(client);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new ArgumentException("Error in to deleted client");
        return result;
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

    public async Task<ClientDto> New(ClientDto clientDto)
    {
        clientDto.ClientId = Guid.NewGuid();
        var client = _mapper.Map<Client>(clientDto);
        _context.Clients.Add(client);
        var result = await _context.SaveChangesAsync();
        if(result ==0) throw new Exception("Error in to create the client");
        return clientDto;
    }

    public async Task<ClientDto> Update(ClientDto clientDto, Guid clientId)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client == null) throw new Exception("the client with id " + clientId + " is not found");

        client.Email = clientDto.Email;
        client.LastName = clientDto.LastName;
        client.Name = clientDto.Name;
        client.PhoneNumber = clientDto.PhoneNumber;
        var result = await _context.SaveChangesAsync();
        if(result == 0) throw new Exception("Error to update client");
        var updatedClient = _mapper.Map<ClientDto>(client);
        return updatedClient;
    }
}
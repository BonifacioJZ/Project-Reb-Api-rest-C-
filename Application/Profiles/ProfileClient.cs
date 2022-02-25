using AutoMapper;
using Domain.Models;
using Domain.Dto.Client;
namespace Application.Profiles;
public class ClientProfile :Profile {
    public ClientProfile(){
        CreateMap<Client,ClientDto>();
        CreateMap<ClientDto,Client>();
        CreateMap<Client, NewClientDto>();
        CreateMap<NewClientDto,Client>();
    }

}
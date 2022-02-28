
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Dto.Client;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController:ControllerBase{
    private readonly IClientService _clientService;
    public ClientController(IClientService clientService){
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult> Index() => Ok(await _clientService.GetAll());

    [HttpGet("id")]
    public async Task<ActionResult> Show(Guid id) => Ok(await _clientService.GetById(id));

    [HttpPost]
    public async Task<ActionResult> Store([FromBody]ClientDto clientDto){
        var newClient = await _clientService.New(clientDto);
        return Created("Created", new{
            newClient
        });
    }

    [HttpPut("id")]
    public async Task<ActionResult> Update([FromBody]ClientDto clientDto,Guid id){
        var updatedClient = await _clientService.Update(clientDto,id);
        return Ok(updatedClient);
    }

    [HttpDelete("id")]
    public async Task<ActionResult> Delete(Guid id){
        var result = await _clientService.Delete(id);
        return Ok(result);
    }

}
using Arsenal.Application.Models;
using Arsenal.Domain.Contracts.Domain.Cliente;
using Arsenal.Domain.Contracts.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Arsenal.Application.Automapper;

namespace Arsenal.Application.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class NegativarClienteController : ControllerBase
  {
    private readonly IClienteService _clienteService;
    private readonly IClienteRepository _clienteRepository;

    public NegativarClienteController(
      IClienteService clienteService,
      IClienteRepository clienteRepository
     )
    {
      _clienteService = clienteService;
      _clienteRepository = clienteRepository;
    }

    [HttpPost]
    [Route("{clienteId}/{motivoId}")]
    public ClienteModel Post(int clienteId, int motivoId)
    {
      var clienteComMotivosDeNegativacao = _clienteService
        .Negativar(clienteId, motivoId);
      
      var clienteAtualizadoEmBanco = _clienteRepository 
        .AlterarCliente(clienteComMotivosDeNegativacao);

      var clienteMapper = new ClienteMapper();

      return clienteMapper.Map(clienteAtualizadoEmBanco);
    }
  }
}
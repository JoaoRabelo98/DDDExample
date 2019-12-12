using Arsenal.Domain.Contracts.Infrastructure.Repository;
using Arsenal.Domain.Enitities.Cliente;

namespace Arsenal.Infrastructure.Repository
{
  public class ClienteRepository : IClienteRepository
  {
    public ClienteEntity AlterarCliente(ClienteEntity clienteEntity)
    {
      return BuscarCliente(clienteEntity);
    }

    public ClienteEntity BuscarCliente(ClienteEntity clienteEntity)
    {
      return new ClienteEntity
      {
        Id = clienteEntity.Id,
        MotivoId = clienteEntity.MotivoId,
        Motivo = clienteEntity.Motivo,
        Negativado = clienteEntity.Negativado,
        Acao = clienteEntity.Acao,
        PrimeiroNome = "Joao Vitor",
        UltimoNome = "Rezende",
        Email = "mail@mail.com.br"
      };
    }
  }
}
using Arsenal.Domain.Enitities.Cliente;

namespace Arsenal.Domain.Contracts.Infrastructure.Repository
{
  public interface IClienteRepository
  {
    ClienteEntity AlterarCliente( ClienteEntity clienteEntity);
  }
}
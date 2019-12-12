using Arsenal.Domain.Enitities.Cliente;

namespace Arsenal.Domain.Contracts.Domain.Cliente
{
  public interface IClienteService
  {
    ClienteEntity Negativar(int id, int motivoId);
  }
}
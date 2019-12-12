using System;
using Arsenal.Domain.Contracts.Domain.Cliente;
using Arsenal.Domain.Enitities.Cliente;

namespace Arsenal.Domain.Cliente
{
  public class ClienteService : IClienteService
  {
    public ClienteEntity Negativar(int id, int motivoId)
    {
      var clienteNegativado = new ClienteEntity
      {
        Id = id,
        MotivoId = motivoId,
        Negativado = true
      };

      if (clienteNegativado.MotivoId == 1)
      {
        clienteNegativado.Motivo = "Carro nao devolvido";
        clienteNegativado.Acao = "Abrir processo";
      }
      else if (clienteNegativado.MotivoId == 2)
      {
        clienteNegativado.Motivo = "Multa nao paga";
        clienteNegativado.Acao = "Aguardar retorno cliente";
      }
      else
      {
        clienteNegativado.Motivo = "Cartao estourado";
        clienteNegativado.Acao = "Negativar nome";
      }

      return clienteNegativado;
    }
  }
}
using Xunit;
using FluentAssertions;
using Arsenal.Domain.Cliente;

namespace Arsenal.Test.Domain.Cliente
{
  public class ClienteServiceTest
  {
    [Theory(DisplayName="Deve negativar um cliente e retornar a acao tomada")]
    [InlineData(1, 2)]
    public void NegativarCliente_PassandoUmMotivoValido_RetornaClienteNegativado(int id, int motivo)
    {
      var ClienteService = new ClienteService();

      var clienteNegativado = ClienteService.Negativar(id, motivo);

      clienteNegativado.Negativado
        .Should()
        .BeTrue();

      clienteNegativado.MotivoId
        .Should()
        .Be(motivo);

      clienteNegativado.Motivo
        .Should()
        .Be("Multa nao paga"); 

      clienteNegativado.Acao
        .Should()
        .Be("Aguardar retorno cliente");
    }
  }
}
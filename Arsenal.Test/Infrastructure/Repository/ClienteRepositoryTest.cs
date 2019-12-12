using Xunit;
using FluentAssertions;
using Moq;
using Arsenal.Domain.Contracts.Infrastructure.Repository;
using Arsenal.Domain.Enitities.Cliente;

namespace Arsenal.Test.Infrastructure.Repository
{
  public class ClienteRepositoryTest
  {
    private readonly Mock<IClienteRepository> _clienteRepositoryMock;
    private readonly ClienteEntity _clienteEntity;
    public ClienteRepositoryTest()
    {
      _clienteRepositoryMock = new Mock<IClienteRepository>();

      _clienteEntity = new ClienteEntity
      {
        Id = 1,
        MotivoId = 2,
        Motivo = "Multa nao paga",
        Negativado = true,
        Acao = "Aguardar retorno cliente"
      };
    }

    [Fact(DisplayName = "Deve fazer a alteracao necessaria no cliente e retornar o mesmo")]
    public void AlterarCliente_QuandoSolicitadoANegativacao_RetornaUsuarioCompleto()
    {
      _clienteRepositoryMock.Setup(x => x.AlterarCliente(_clienteEntity))
        .Returns(new ClienteEntity
        {
          Id = 1,
          MotivoId = 2,
          Motivo = "Multa nao paga",
          Negativado = true,
          Acao = "Aguardar retorno cliente",
          PrimeiroNome = "Joao Vitor",
          UltimoNome = "Rezende",
          Email = "mail@mail.com.br"
        });

      var clienteAtualizado = _clienteRepositoryMock.Object
      .AlterarCliente(_clienteEntity);

      clienteAtualizado.Id
        .Should()
        .Equals(_clienteEntity.Id);
      
      clienteAtualizado.Motivo
        .Should()
        .Equals(_clienteEntity.Motivo);

      clienteAtualizado.PrimeiroNome
        .Should()
        .NotBe(string.Empty);

      clienteAtualizado.Email
        .Should()
        .NotBe(string.Empty);
    }
  }
}
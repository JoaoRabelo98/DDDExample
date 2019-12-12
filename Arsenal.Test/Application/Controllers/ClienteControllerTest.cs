using Xunit;
using FluentAssertions;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using Arsenal.Application.Models;

namespace Arsenal.Test.Application.Controllers
{
  public class ClienteControllerTest : ContollerTestSetup
  {
    private readonly string ROTA_CLIENTE_NEVATIVAR = "/api/negativarcliente/1/2";

    [Fact(DisplayName = "Deve responder com status 200 em /api/negativarcliente/{clienteId}/{motivoId}")]
    public async void NegativarClienteController_RetornarStatus200()
    {
      var request = new HttpRequestMessage(HttpMethod.Post, ROTA_CLIENTE_NEVATIVAR);

      var response = await _client.SendAsync(request);

      response.StatusCode
        .Should()
        .Be(HttpStatusCode.OK);
    }

    [Fact(DisplayName = "Deve retornar cliente negativado em /api/negativarcliente/{clienteId}/{motivoId}")]
    public async void TestName()
    {
      var request = new HttpRequestMessage(HttpMethod.Post, ROTA_CLIENTE_NEVATIVAR);

      var response = await _client.SendAsync(request);

      var data = await response.Content.ReadAsStringAsync();

      var clienteAtualizado = JsonConvert.DeserializeObject<ClienteModel>(data);

      response.StatusCode
        .Should()
        .Be(HttpStatusCode.OK);

      clienteAtualizado.NomeCompleto
        .Should()
        .NotBe(string.Empty);

      clienteAtualizado.Negativado
        .Should()
        .BeTrue();
    }
  }
}
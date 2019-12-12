using AutoMapper;
using Arsenal.Application.Models;
using Arsenal.Domain.Enitities.Cliente;

namespace Arsenal.Application.Automapper
{
  public class ClienteMapper : Profile
  {
    private readonly MapperConfiguration _config;

    public ClienteMapper()
    {
      _config = new MapperConfiguration(config =>
      {
        config.CreateMap<ClienteEntity, ClienteModel>()
          .ForMember(dest => dest.NomeCompleto, options =>
            options.MapFrom(src => src.PrimeiroNome)).ReverseMap();

        config.CreateMap<ClienteEntity, ClienteModel>()
          .ForMember(dest => dest.NomeCompleto, options =>
            options.MapFrom(src => src.UltimoNome)).ReverseMap();
      });
    }

    public ClienteModel Map(ClienteEntity clienteEntity)
    {
      return _config.CreateMapper().Map<ClienteModel>(clienteEntity);
    }
  }
}
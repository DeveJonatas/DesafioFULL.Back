using AutoMapper;
using Desafio.Models;
using Desafio.Models.DTOs;

namespace Desafio.API.Infra.AutoMapper
{
    public class MappingModel : Profile
    {
        public MappingModel()
        {
            CreateMap<TituloRequest, Titulo>().ReverseMap();

            CreateMap<ParcelaRequest, Parcela>().ReverseMap();
        }
    }
}

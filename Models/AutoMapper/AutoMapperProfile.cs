using AutoMapper;
using MinimalApi.Models.Dto;
using MinimalApi.Models.Entities;

namespace MinimalApi.Models.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario, UsuarioGetDto>();

        }
    }
}

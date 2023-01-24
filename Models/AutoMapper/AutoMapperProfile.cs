using AutoMapper;
using MinimalApi.Models.Dto;
using MinimalApi.Models.Entities;

namespace MinimalApi.Models.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<EmailPasswordDto, Usuario>();
        }
    }
}

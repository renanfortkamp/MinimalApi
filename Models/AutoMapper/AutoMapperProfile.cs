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
            CreateMap<Usuario, UsuarioGetDto>().AfterMap((src, dest) =>
            {
                dest.NomeCompleto = src.Nome + " " + src.SobreNome;
            })
            .AfterMap((src, dest) =>
            {
                dest.DataNascimento = src.DataNascimento.ToString("dd/MM/yyyy");
            });

        }
    }
}

using System.ComponentModel.DataAnnotations;
using MinimalApi.Models.Entities;

namespace MinimalApi.Models.Dto
{
    public class UsuarioDto
    {
        public string NomeCompleto { get; set; }

        public DateTime DataNascimento { get; set; }


        public UsuarioDto(Usuario usuario)
        {
            NomeCompleto = $"{usuario.Nome} {usuario.SobreNome}";
        }


    }
}

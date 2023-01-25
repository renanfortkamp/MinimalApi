using System.ComponentModel.DataAnnotations;
using MinimalApi.Models.Entities;

namespace MinimalApi.Models.Dto
{
    public class UsuarioGetDto
    {
        public string NomeCompleto { get; set; }
        public string DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}

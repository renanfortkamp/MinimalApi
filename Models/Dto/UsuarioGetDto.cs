using System.ComponentModel.DataAnnotations;
using MinimalApi.Models.Entities;

namespace MinimalApi.Models.Dto
{
    public class UsuarioGetDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Nome precisa ter entre 3 a 100 caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Sobrenome precisa ter entre 3 a 200 caracteres.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string SobreNome { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Digite uma data valida. Ex:AAAA-MM-DD(1993-04-02)")]
        public DateTime DataNascimento { get; set; }

        [StringLength(100, ErrorMessage = "Telefone precisa ter entre 5 e 100 Caracteres.", MinimumLength = 5)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }
    }
}

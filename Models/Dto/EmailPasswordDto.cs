using System.ComponentModel.DataAnnotations;

namespace MinimalApi.Models.Dto
{
    public class EmailPasswordDto
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Digite um e-mail valido ex:email@provedor.com")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "Senha precisa ter entre 6 a 18 Caracteres", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

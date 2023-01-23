using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength =3)]
        public string Nome { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string SobreNome { get; set; }

        [Required]
        [Column(TypeName ="Date")]
        public DateTime DataNascimento { get; set; }


        [StringLength(100)]
        public string? Genero { get; set; }

        [Required]
        [StringLength(11,MinimumLength = 11)]
        public string Cpf { get; set; }

        [StringLength(100,MinimumLength =5)]
        public string Telefone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Cristal.Application.Models
{
    public class AutenticarPostModel
    {
        [Required(ErrorMessage = "O campo email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        [MinLength(5, ErrorMessage = "A senha precisa ter no mínimo {1} caracteres.")]
        public string? Senha { get; set; }
    }
}

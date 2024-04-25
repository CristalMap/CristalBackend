using System.ComponentModel.DataAnnotations;

namespace Cristal.Application.Models
{
    public class RecuperarSenhaPostModel
    {
        [Required(ErrorMessage = "O campo email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string? Email { get; set; }
    }
}

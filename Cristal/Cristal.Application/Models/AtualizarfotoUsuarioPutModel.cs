using System.ComponentModel.DataAnnotations;

namespace Cristal.Application.Models
{
    public class AtualizarfotoUsuarioPutModel
    {
        [Required(ErrorMessage = "O campo foto é obrigatório.")]
        public string? FotoBase64 { get; set; }
    }
}

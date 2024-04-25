using Cristal.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Cristal.Application.Models
{
    public class ListarDenunciaGetModel
    {
        [RegularExpression("^[a-zA-Z0-9\\s\\S]{5,80}$", ErrorMessage = "Informe um titulo válido entre 5 a 80 caracteres.")]
        public string? Titulo { get; set; }
        public StatusDenuncia? Status { get; set; }
        public int PrimeiroItem { get; set; }
        public int UltimoItem { get; set; }
    }
}

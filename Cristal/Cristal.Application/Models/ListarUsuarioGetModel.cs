using System.ComponentModel.DataAnnotations;

namespace Cristal.Application.Models
{
    public class ListarUsuarioGetModel
    {
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{3,80}$", ErrorMessage = "Informe um nome válido entre 3 a 80 caracteres.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string? Email { get; set; }

        public int PrimeiroItem { get; set; }

        public int UltimoItem { get; set; }

    }
}

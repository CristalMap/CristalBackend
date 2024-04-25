using System.ComponentModel.DataAnnotations;

namespace Cristal.Application.Models
{
    public class AtualizarUsuarioPutModel
    {
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{3,80}$", ErrorMessage = "Informe um nome válido entre 3 a 80 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string? Email { get; set; }

        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Informe um telefone válido com 11 dígitos numéricos.")]
        public string? Telefone { get; set; }

        public bool Administrador { get; set; }
        public bool TelaPerfil { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Cristal.Application.Models
{
    public class CriarContaPostModel
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{3,80}$", ErrorMessage = "Informe um nome válido entre 3 a 80 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo telefone é obrigatório.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Informe um telefone válido com 11 dígitos numéricos.")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-z]).{8,}$",
            ErrorMessage = "A senha precisa ter pelo menos 1 letra maiúscula, 1 letra minúscula, 1 número, " +
            "1 caractere especial e no mínimo 8 caracteres")]
        public string? Senha { get; set; }
    }
}

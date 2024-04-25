using System.ComponentModel.DataAnnotations;

namespace Cristal.Application.Models
{
    public class AtualizarSenhaPutModel
    {
        public string? SenhaAtual { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-z]).{8,}$",
        ErrorMessage = "A senha precisa ter pelo menos 1 letra maiúscula, 1 letra minúscula, 1 número, " +
        "1 caractere especial e no mínimo 8 caracteres")]
        public string? Senha { get; set; }
    }
}

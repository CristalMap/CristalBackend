using System.ComponentModel.DataAnnotations;

namespace Cristal.Application.Models
{
    public class CriarDenunciaPostModel
    {
        [Required(ErrorMessage = "O campo titulo é obrigatório.")]
        [RegularExpression("^[a-zA-Z0-9\\s\\S]{5,80}$", ErrorMessage = "Informe um titulo válido entre 5 a 80 caracteres.")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório.")]
        [RegularExpression("^[a-zA-Z0-9\\s\\S]{20,700}$", ErrorMessage = "Informe uma descrição válida entre 20 a 700 caracteres.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo endereço é obrigatório.")]
        public CriarEnderecoPostModel? Endereco { get; set; }

        [Required(ErrorMessage = "O campo foto é obrigatório.")]
        public string? FotoBase64 { get; set; }

        public int QuantidadeMamiferos { get; set; }

        public int QuantidadeAves { get; set; }

        public int QuantidadeRepteis { get; set; }

        public int QuantidadePeixes { get; set; }

        [Required(ErrorMessage = "O campo usuário é obrigatório.")]
        public Guid? GuidUsuario { get; set; }
    }
}

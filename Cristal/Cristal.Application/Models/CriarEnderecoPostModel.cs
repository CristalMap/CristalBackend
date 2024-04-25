using System.ComponentModel.DataAnnotations;

namespace Cristal.Application.Models
{
    public class CriarEnderecoPostModel
    {
        [Required(ErrorMessage = "O campo endereço é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo latitude é obrigatório.")]
        public double? Latitude { get; set; }

        [Required(ErrorMessage = "O campo longitude é obrigatório.")]
        public double? Longitude { get; set; }
    }
}

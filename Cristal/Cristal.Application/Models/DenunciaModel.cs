using Cristal.Domain.Enum;

namespace Cristal.Application.Models
{
    public class DenunciaModel
    {
        public string Guid { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public EnderecoModel? Endereco { get; set; }
        public string? FotoBase64 { get; set; }
        public StatusDenuncia Status { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public int QuantidadeMamiferos { get; set; }
        public int QuantidadeAves { get; set; }
        public int QuantidadeRepteis { get; set; }
        public int QuantidadePeixes { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}

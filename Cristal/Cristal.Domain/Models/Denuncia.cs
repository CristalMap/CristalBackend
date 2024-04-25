using Cristal.Domain.Enum;

namespace Cristal.Domain.Models
{
    public class Denuncia
    {
        private Guid? _guid;
        private string? _titulo;
        private string? _descricao;
        private Endereco? _endereco;
        private Guid? _guidEndereco;
        private string? _fotoBase64;
        private StatusDenuncia? _status;
        private DateTime _dataHoraCriacao;
        private int _quantidadeMamiferos;
        private int _quantidadeAves;
        private int _quantidadeRepteis;
        private int _quantidadePeixes;
        private Usuario? _usuario;
        private Guid _guidUsuario;

        public Guid? Guid { get => _guid; set => _guid = value; }
        public string? Titulo { get => _titulo; set => _titulo = value; }
        public string? Descricao { get => _descricao; set => _descricao = value; }
        public Endereco? Endereco { get => _endereco; set => _endereco = value; }
        public Guid? GuidEndereco { get => _guidEndereco; set => _guidEndereco = value; }
        public string? FotoBase64 { get => _fotoBase64; set => _fotoBase64 = value; }
        public StatusDenuncia? Status { get => _status; set => _status = value; }
        public DateTime DataHoraCriacao { get => _dataHoraCriacao; set => _dataHoraCriacao = value; }
        public int QuantidadeMamiferos { get => _quantidadeMamiferos; set => _quantidadeMamiferos = value; }
        public int QuantidadeAves { get => _quantidadeAves; set => _quantidadeAves = value; }
        public int QuantidadeRepteis { get => _quantidadeRepteis; set => _quantidadeRepteis = value; }
        public int QuantidadePeixes { get => _quantidadePeixes; set => _quantidadePeixes = value; }
        public Usuario? Usuario { get => _usuario; set => _usuario = value; }
        public Guid GuidUsuario { get => _guidUsuario; set => _guidUsuario = value; }
    }
}

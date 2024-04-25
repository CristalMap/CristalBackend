namespace Cristal.Domain.Models
{
    public class Usuario
    {
        private Guid? _guid;
        private string? _nome;
        private string? _email;
        private string? _telefone;
        private string? _senha;
        private DateTime _datahoraCriacao;
        private int _pontos;
        private string? _foto;
        private bool _administrador;
        private List<Denuncia>? _denuncias;

        public Guid? Guid { get => _guid; set => _guid = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? Telefone { get => _telefone; set => _telefone = value; }
        public string? Senha { get => _senha; set => _senha = value; }
        public DateTime DatahoraCriacao { get => _datahoraCriacao; set => _datahoraCriacao = value; }
        public int Pontos { get => _pontos; set => _pontos = value; }
        public string? Foto { get => _foto; set => _foto = value; }
        public bool Administrador { get => _administrador; set => _administrador = value; }
        public List<Denuncia>? Denuncias { get => _denuncias; set => _denuncias = value; }
    }
}

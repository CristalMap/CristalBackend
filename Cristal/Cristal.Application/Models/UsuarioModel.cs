namespace Cristal.Application.Models
{
    public class UsuarioModel
    {
        public Guid Guid { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataHoraCriacao { get; set; }
        public int Pontos { get; set; }
        public string? Foto { get; set; }
        public bool Administrador { get; set; }
    }
}

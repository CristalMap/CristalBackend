namespace Cristal.Domain.Models
{
    public class AtualizarSenha
    {
        private string? _senhaAtual;
        private string? _senha;

        public string? SenhaAtual { get => _senhaAtual; set => _senhaAtual = value; }
        public string? Senha { get => _senha; set => _senha = value; }
    }
}

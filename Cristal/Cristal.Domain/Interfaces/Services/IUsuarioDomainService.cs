using Cristal.Domain.Models;

namespace Cristal.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        void CriarUsuario(Usuario usuario);
        Usuario Autenticar(string email, string senha);
        Usuario RecuperarSenha(string email);
        Usuario AtualizarUsuario(Guid guid, Usuario usuario, bool telaPerfil);
        void AtualizarSenha(Guid guid, AtualizarSenha senhas);
        void AtualizarFotoUsuario(Guid guid, string fotoBase64);
        IEnumerable<Usuario> FiltrarEpaginarUsuarios(Usuario filtro, int primeiroItem, int ultimoItem);
        long FiltrarEpaginarUsuariosQuantidade(Usuario filtro);
        void ExcluirUsuario(Guid guid);
    }
}

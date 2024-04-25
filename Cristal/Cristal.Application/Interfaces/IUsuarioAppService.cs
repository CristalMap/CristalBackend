using Cristal.Application.Models;

namespace Cristal.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        UsuarioModel Criarconta(CriarContaPostModel model);
        UsuarioModel Autenticar(AutenticarPostModel model);
        UsuarioModel RecuperarSenha(RecuperarSenhaPostModel model);
        UsuarioModel AtualizarUsuario(Guid guid, AtualizarUsuarioPutModel model);
        void AtualizarSenha(Guid guid, AtualizarSenhaPutModel model);
        void AtualizarFotoUsuario(Guid guid, string fotoBase64);
        IEnumerable<UsuarioModel> FiltrarEpaginarUsuarios(ListarUsuarioGetModel model);
        long FiltrarEpaginarUsuariosQuantidade(ListarUsuarioGetModel model);
        void ExcluirUsuario(Guid guid);
    }
}

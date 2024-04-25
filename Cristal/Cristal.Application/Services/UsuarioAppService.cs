using AutoMapper;
using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Cristal.Domain.Interfaces.Services;
using Cristal.Domain.Models;

namespace Cristal.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioDomainService usuarioDomainService, IMapper mapper)
        {
            _usuarioDomainService = usuarioDomainService;
            _mapper = mapper;
        }

        public UsuarioModel Criarconta(CriarContaPostModel model)
        {
            var usuario = _mapper.Map<Usuario>(model);

            _usuarioDomainService.CriarUsuario(usuario);

            return _mapper.Map<UsuarioModel>(usuario);
        }

        public UsuarioModel Autenticar(AutenticarPostModel model)
        {
            var usuario = _usuarioDomainService.Autenticar(model.Email, model.Senha);
            return _mapper.Map<UsuarioModel>(usuario);
        }

        public UsuarioModel RecuperarSenha(RecuperarSenhaPostModel model)
        {
            var usuario = _usuarioDomainService.RecuperarSenha(model.Email);
            return _mapper.Map<UsuarioModel>(usuario);
        }

        public UsuarioModel AtualizarUsuario(Guid guid, AtualizarUsuarioPutModel model)
        {
            var usuario = _mapper.Map<Usuario>(model);

            var usuarioAtualizado = _usuarioDomainService.AtualizarUsuario(guid, usuario, model.TelaPerfil);

            return _mapper.Map<UsuarioModel>(usuarioAtualizado);
        }

        public void AtualizarSenha(Guid guid, AtualizarSenhaPutModel model)
        {
            var senhas = _mapper.Map<AtualizarSenha>(model);

            _usuarioDomainService.AtualizarSenha(guid, senhas);
        }

        public void AtualizarFotoUsuario(Guid guid, string fotoBase64)
        {
            _usuarioDomainService.AtualizarFotoUsuario(guid, fotoBase64);
        }

        public IEnumerable<UsuarioModel> FiltrarEpaginarUsuarios(ListarUsuarioGetModel model)
        {
            var filtro = _mapper.Map<Usuario>(model);
            var usuariosSelecionados = _usuarioDomainService.FiltrarEpaginarUsuarios(filtro, model.PrimeiroItem, model.UltimoItem);
            return _mapper.Map<IEnumerable<UsuarioModel>>(usuariosSelecionados);
        }

        public long FiltrarEpaginarUsuariosQuantidade(ListarUsuarioGetModel model)
        {
            var filtro = _mapper.Map<Usuario>(model);
            return _usuarioDomainService.FiltrarEpaginarUsuariosQuantidade(filtro);
        }

        public void ExcluirUsuario(Guid guid)
        {
            _usuarioDomainService.ExcluirUsuario(guid);
        }
    }
}

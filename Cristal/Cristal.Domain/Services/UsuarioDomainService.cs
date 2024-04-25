using Azure.Storage.Blobs;
using Bogus;
using Cristal.Domain.DTOs;
using Cristal.Domain.Helpers;
using Cristal.Domain.Interfaces.Messages;
using Cristal.Domain.Interfaces.Repositories;
using Cristal.Domain.Interfaces.Services;
using Cristal.Domain.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Cristal.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMessageProducer _messageProducer;

        public UsuarioDomainService(IUsuarioRepository usuarioRepository, IMessageProducer messageProducer)
        {
            _usuarioRepository = usuarioRepository;
            _messageProducer = messageProducer;
        }

        public void CriarUsuario(Usuario usuario)
        {
            if (_usuarioRepository.Find(where: u => u.Email.Equals(usuario.Email)) != null)
            {
                throw new ArgumentException("O email informado já está cadastrado no sistema.");
            }
            else
            {
                usuario.Senha = MD5Helper.Encrypt(usuario.Senha);
                _usuarioRepository.Add(usuario);
            }
        }

        public Usuario Autenticar(string email, string senha)
        {
            var senhaCriptografada = MD5Helper.Encrypt(senha);
            var usuario = _usuarioRepository.Find(u => u.Email.Equals(email) && u.Senha.Equals(senhaCriptografada));

            if (usuario is null)
            {
                throw new ArgumentException("Acesso negado, usuário não encontrado");
            }
            else
            {
                return usuario;
            }
        }

        public Usuario RecuperarSenha(string email)
        {
            var usuario = _usuarioRepository.Find(u => u.Email.Equals(email));

            if (usuario is null)
            {
                throw new ArgumentException("Email invalido, verifique o email informado.");
            }
            else
            {
                var faker = new Faker();
                var novaSenha = $"{faker.Internet.Password(12)}@";

                usuario.Senha = MD5Helper.Encrypt(novaSenha);
                _usuarioRepository.Update(usuario);

                var emailMessageDTO = new EmailMessageDTO
                {
                    MailTo = usuario.Email,
                    Subject = "Cristal - Recuperação de senha de acesso",
                    IsBodyHtml = true,
                    Body = $@"
                           <div>
                               <p>Olá <strong>{usuario.Nome}</strong>, uma nova senha foi gerada com sucesso.</p>
                               <p>Utilize a senha <strong>{novaSenha}</strong> para acessar sua conta.</p>
                               <p>Atenciosamente,</p>
                               <p>Equipe <strong>Cristal. =)</strong></p>
                           </div>"
                };

                _messageProducer.Send(JsonConvert.SerializeObject(emailMessageDTO));

                return usuario;
            }
        }

        public Usuario AtualizarUsuario(Guid guid, Usuario usuario, bool telaPerfil)
        {
            var usuarioExistente = _usuarioRepository.Find(u => u.Guid.Equals(guid));

            if (usuarioExistente is null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }
            else
            {
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;
                usuarioExistente.Telefone = usuario.Telefone;
                if(telaPerfil == false) 
                {

                    usuarioExistente.Administrador = usuario.Administrador;
                }

                _usuarioRepository.Update(usuarioExistente);

                return usuarioExistente;
            }
        }

        public void AtualizarSenha(Guid guid, AtualizarSenha senhas)
        {
            var usuarioExistente = _usuarioRepository.Find(u => u.Guid.Equals(guid));

            if (usuarioExistente is null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }
            else
            {
                if (MD5Helper.Encrypt(senhas.SenhaAtual) != usuarioExistente.Senha)
                {
                    throw new ArgumentException("Senha atual inválida");
                }
                else
                {
                    usuarioExistente.Senha = MD5Helper.Encrypt(senhas.Senha);

                    _usuarioRepository.Update(usuarioExistente);
                }
            }
        }

        public void AtualizarFotoUsuario(Guid guid, string fotoBase64)
        {
            var usuarioExistente = _usuarioRepository.Find(u => u.Guid.Equals(guid));

            if (usuarioExistente is null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }
            else
            {
                var nomeFoto = Guid.NewGuid().ToString() + ".jpg";
                var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(fotoBase64, "");
                byte[] imageBytes = Convert.FromBase64String(data);
                var blobClient = new BlobClient("DefaultEndpointsProtocol=https;AccountName=;AccountKey=;", "usuario", nomeFoto);

                using (var steam = new MemoryStream(imageBytes))
                {
                    blobClient.Upload(steam);
                }

                usuarioExistente.Foto = blobClient.Uri.AbsoluteUri;
                _usuarioRepository.Update(usuarioExistente);
            }
        }

        public IEnumerable<Usuario> FiltrarEpaginarUsuarios(Usuario filtro, int primeiroItem, int ultimoItem)
        {
            var usuarios = _usuarioRepository.FiltrarEpaginarUsuarios(filtro);
            if (!usuarios.Any())
            {
                throw new ArgumentException("Nenhum usuário encontrado.");
            }
            else
            {
                return usuarios.Skip(primeiroItem).Take(ultimoItem);
            }
        }

        public long FiltrarEpaginarUsuariosQuantidade(Usuario filtro)
        {
            var quantidade = _usuarioRepository.FiltrarEpaginarUsuarios(filtro).Count();
            if (quantidade == 0)
            {
                throw new ArgumentException("Nenhum usuário encontrado.");
            }
            else
            {
                return quantidade;
            }
        }

        public void ExcluirUsuario(Guid guid)
        {
            var usuarioExistente = _usuarioRepository.Find(guid);

            if (usuarioExistente is null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }
            else
            {
                _usuarioRepository.Delete(usuarioExistente);
            }
        }
    }
}

using Azure.Storage.Blobs;
using Cristal.Domain.DTOs;
using Cristal.Domain.Enum;
using Cristal.Domain.Interfaces.Messages;
using Cristal.Domain.Interfaces.Repositories;
using Cristal.Domain.Interfaces.Services;
using Cristal.Domain.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Cristal.Domain.Services
{
    public class DenunciaDomainService : IDenunciaDomainService
    {
        private readonly IDenunciaRepository _denunciaRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMessageProducer _messageProducer;

        public DenunciaDomainService(IDenunciaRepository denunciaRepository, IEnderecoRepository enderecoRepository,
        IUsuarioRepository usuarioRepository, IMessageProducer messageProducer)
        {
            _denunciaRepository = denunciaRepository;
            _enderecoRepository = enderecoRepository;
            _usuarioRepository = usuarioRepository;
            _messageProducer = messageProducer;
        }

        public Denuncia AtualizarDenuncia(Guid guid, Denuncia denuncia)
        {
            var denunciaExistente = _denunciaRepository.Find(guid);
            var enderecoExistente = _enderecoRepository.Find(e => e.Guid == denunciaExistente.GuidEndereco);

            if (denunciaExistente is null)
            {
                throw new ArgumentException("Denúncia não encontrado.");
            }
            else
            {
                denunciaExistente.Titulo = denuncia.Titulo;
                denunciaExistente.Descricao = denuncia.Descricao;

                if (denuncia.Endereco.Nome is not null)
                {
                    enderecoExistente.Nome = denuncia.Endereco.Nome;
                    enderecoExistente.Latitude = denuncia.Endereco.Latitude;
                    enderecoExistente.Longitude = denuncia.Endereco.Longitude;
                    _enderecoRepository.Update(enderecoExistente);
                    denunciaExistente.GuidEndereco = _enderecoRepository.Find(where: e => e.Nome.Equals(enderecoExistente.Nome)).Guid;
                    denunciaExistente.Endereco = null;
                }

                if (denuncia.FotoBase64 != null && denuncia.FotoBase64 != "")
                {
                    var nomeFoto = Guid.NewGuid().ToString() + ".jpg";
                    var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(denuncia.FotoBase64, "");
                    var imageBytes = Convert.FromBase64String(data);
                    var blobClient = new BlobClient("DefaultEndpointsProtocol=https;AccountName=;AccountKey=", "denuncia", nomeFoto);
                    using (var steam = new MemoryStream(imageBytes))
                    {
                        blobClient.Upload(steam);
                    }
                    denunciaExistente.FotoBase64 = blobClient.Uri.AbsoluteUri;
                }

                denunciaExistente.QuantidadeMamiferos = denuncia.QuantidadeMamiferos;
                denunciaExistente.QuantidadeAves = denuncia.QuantidadeAves;
                denunciaExistente.QuantidadeRepteis = denuncia.QuantidadeRepteis;
                denunciaExistente.QuantidadePeixes = denuncia.QuantidadePeixes;

                _denunciaRepository.Update(denunciaExistente);
                return _denunciaRepository.Find(guid);
            }
        }

        public void CriarDenuncia(Denuncia denuncia)
        {
            _enderecoRepository.Add(denuncia.Endereco);

            denuncia.GuidEndereco = _enderecoRepository.Find(where: e => e.Nome.Equals(denuncia.Endereco.Nome)).Guid;
            denuncia.Endereco = null;

            var nomeFoto = Guid.NewGuid().ToString() + ".jpg";
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(denuncia.FotoBase64, "");
            byte[] imageBytes = Convert.FromBase64String(data);
            var blobClient = new BlobClient("DefaultEndpointsProtocol=https;AccountName=;AccountKey=;", "denuncia", nomeFoto);
            using (var steam = new MemoryStream(imageBytes))
            {
                blobClient.Upload(steam);
            }
            denuncia.FotoBase64 = blobClient.Uri.AbsoluteUri;

            _denunciaRepository.Add(denuncia);
        }

        public void ExcluirDenuncia(Guid guid)
        {
            var denunciaExistete = _denunciaRepository.Find(guid);

            if (denunciaExistete is null)
            {
                throw new ArgumentException("Denúncia não encontrada.");
            }
            else
            {
                _denunciaRepository.Delete(denunciaExistete);
            }
        }

        public IEnumerable<Denuncia> FiltrarEPaginarDenuncias(Denuncia filtro, int primeiroItem, int ultimoItem)
        {
            var denuncias = _denunciaRepository.FiltrarEPaginarDenuncias(filtro);
            if (!denuncias.Any())
            {
                throw new ArgumentException("Nenhuma denúncia encontrada.");
            }
            else
            {
                return denuncias.Skip(primeiroItem).Take(ultimoItem);
            }
        }

        public long FiltrarEPaginarDenunciasQuantidade(Denuncia filtro)
        {
            var denuncias = _denunciaRepository.FiltrarEPaginarDenuncias(filtro).Count();
            if (denuncias == 0)
            {
                throw new ArgumentException("Nenhuma denúncia encontrada.");
            }
            else
            {
                return denuncias;
            }
        }

        public IEnumerable<DenunciaEstatistica> ListarDenunciaEstatistica(Guid guid)
        {
            var denunciaEstatistica = _denunciaRepository.ListarDenunciaEstatistica(guid);
            if (!denunciaEstatistica.Any())
            {
                throw new ArgumentException("Nenhuma denúncia encontrada.");
            }
            else
            {
                return denunciaEstatistica;
            }
        }

        public IEnumerable<Denuncia> ListarDenuncias()
        {
            var denuncias = _denunciaRepository.GetAll();

            if (!denuncias.Any())
            {
                throw new ArgumentException("Nenhuma denúncia encontrada.");
            }
            else
            {
                return denuncias;
            }
        }

        public IEnumerable<Denuncia> ListarDenunciasAprovadas()
        {
            var denunciasAprovada = _denunciaRepository.ListarDenunciasAprovadas();

            if (!denunciasAprovada.Any())
            {
                throw new ArgumentException("Nenhuma denúncia aprovada encontrada.");
            }
            else
            {
                return denunciasAprovada.OrderByDescending(d => d.DataHoraCriacao);
            }
        }

        public IEnumerable<Denuncia> ListarDenunciasUsuario(Guid guid)
        {
            var denunciasUsuario = _denunciaRepository.ListarDenunciasUsuario(guid);

            if (!denunciasUsuario.Any())
            {
                throw new ArgumentException("Nenhuma denúncia encontrada.");
            }
            else
            {
                return denunciasUsuario.OrderByDescending(d => d.DataHoraCriacao);
            }
        }

        public void MudarStatusDenuncia(Guid guid, StatusDenuncia model)
        {
            var denuncia = _denunciaRepository.Find(guid);

            if (denuncia is null)
            {
                throw new ArgumentException("Denúncia não encontrada.");
            }
            else
            {
                denuncia.Status = model;
                _denunciaRepository.Update(denuncia);

                var usuario = _usuarioRepository.Find(denuncia.GuidUsuario);

                if (model == StatusDenuncia.Aprovada)
                {
                    usuario.Pontos += 10;
                    _usuarioRepository.Update(usuario);
                    var emailMessageDTO = new EmailMessageDTO
                    {
                        MailTo = usuario.Email,
                        Subject = "Cristal - Denúncia aprovada",
                        IsBodyHtml = true,
                        Body = $@"
                           <div>
                               <p>Olá <strong>{usuario.Nome}</strong>, a denúncia <strong>{denuncia.Titulo}</strong> sua foi aprovada.</p>
                               <p>Você recebeu 10 pontos. Agora você tem {usuario.Pontos} pontos.</p>
                               <p>Atenciosamente,</p>
                               <p>Equipe <strong>Cristal. =)</strong></p>
                           </div>"
                    };

                    _messageProducer.Send(JsonConvert.SerializeObject(emailMessageDTO));
                }
                else if (model == StatusDenuncia.Pendente)
                {
                    usuario.Pontos -= 10;
                    _usuarioRepository.Update(usuario);

                    var emailMessageDTO = new EmailMessageDTO
                    {
                        MailTo = usuario.Email,
                        Subject = "Cristal - Denúncia alterada",
                        IsBodyHtml = true,
                        Body = $@"
                           <div>
                               <p>Olá <strong>{usuario.Nome}</strong>, a denúncia <strong>{denuncia.Titulo}</strong> sua foi alterada para pendente.</p>
                               <p>Os 10 pontos ganhos foram removidos. Agora você tem {usuario.Pontos} pontos.</p>
                               <p>Atenciosamente,</p>
                               <p>Equipe <strong>Cristal. =)</strong></p>
                           </div>"
                    };

                    _messageProducer.Send(JsonConvert.SerializeObject(emailMessageDTO));
                }
                else
                {
                    var emailMessageDTO = new EmailMessageDTO
                    {
                        MailTo = usuario.Email,
                        Subject = "Cristal - Denúncia reprovada",
                        IsBodyHtml = true,
                        Body = $@"
                           <div>
                               <p>Olá <strong>{usuario.Nome}</strong>, a denúncia <strong>{denuncia.Titulo}</strong> foi reprovada.</p>
                               <p>Atenciosamente,</p>
                               <p>Equipe <strong>Cristal. =)</strong></p>
                           </div>"
                    };

                    _messageProducer.Send(JsonConvert.SerializeObject(emailMessageDTO));
                }
            }
        }
    }
}

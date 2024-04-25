using AutoMapper;
using Cristal.Application.Models;
using Cristal.Domain.Enum;
using Cristal.Domain.Models;

namespace Cristal.Application.Mappings
{
    public class ModelToEntityMap : Profile
    {
        public ModelToEntityMap()
        {
            CreateMap<CriarContaPostModel, Usuario>().AfterMap((model, entity) =>
            {
                entity.Guid = Guid.NewGuid();
                entity.DatahoraCriacao = DateTime.Now;
                entity.Pontos = 0;
                entity.Foto = "";
                entity.Administrador = false;
            });
            CreateMap<AtualizarUsuarioPutModel, Usuario>();
            CreateMap<AtualizarSenhaPutModel, AtualizarSenha>();
            CreateMap<CriarDenunciaPostModel, Denuncia>().AfterMap((model, entity) =>
            {
                entity.Status = StatusDenuncia.Pendente;
                entity.DataHoraCriacao = DateTime.Now;
            });
            CreateMap<CriarEnderecoPostModel, Endereco>();
            CreateMap<ListarUsuarioGetModel, Usuario>();
            CreateMap<ListarDenunciaGetModel, Denuncia>();
            CreateMap<AtualizarDenunciaPutModel, Denuncia>();
            CreateMap<AtualizarEnderecoPutModel, Endereco>();
        }
    }
}

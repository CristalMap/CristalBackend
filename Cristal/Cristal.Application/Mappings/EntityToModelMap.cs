using AutoMapper;
using Cristal.Application.Models;
using Cristal.Domain.Models;

namespace Cristal.Application.Mappings
{
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Usuario, UsuarioModel>();
            CreateMap<Denuncia, DenunciaModel>();
            CreateMap<Endereco, EnderecoModel>();
            CreateMap<DenunciaEstatistica, DenunciaEstatisticaModel>();
        }
    }
}

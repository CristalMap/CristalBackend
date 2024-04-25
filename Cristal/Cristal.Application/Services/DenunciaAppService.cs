using AutoMapper;
using Cristal.Application.Interfaces;
using Cristal.Application.Models;
using Cristal.Domain.Enum;
using Cristal.Domain.Interfaces.Services;
using Cristal.Domain.Models;

namespace Cristal.Application.Services
{
    public class DenunciaAppService : IDenunciaAppService
    {
        private readonly IMapper _mapper;
        private readonly IDenunciaDomainService _denunciaDomainService;

        public DenunciaAppService(IMapper mapper, IDenunciaDomainService denunciaDomainService)
        {
            _mapper = mapper;
            _denunciaDomainService = denunciaDomainService;

        }

        public DenunciaModel AtualizarDenuncia(Guid guid, AtualizarDenunciaPutModel model)
        {
            var denuncia = _mapper.Map<Denuncia>(model);
            var denunciaEditada = _denunciaDomainService.AtualizarDenuncia(guid, denuncia);
            return _mapper.Map<DenunciaModel>(denunciaEditada);
        }

        public void CriarDenuncia(CriarDenunciaPostModel model)
        {
            var denuncia = _mapper.Map<Denuncia>(model);

            _denunciaDomainService.CriarDenuncia(denuncia);
        }

        public void ExcluirDenuncia(Guid guid)
        {
            _denunciaDomainService.ExcluirDenuncia(guid);
        }

        public IEnumerable<DenunciaModel> FiltrarEPaginarDenuncias(ListarDenunciaGetModel model)
        {
            var filtro = _mapper.Map<Denuncia>(model);
            var denunciasSelecionadas = _denunciaDomainService.FiltrarEPaginarDenuncias(filtro, model.PrimeiroItem, model.UltimoItem);
            return _mapper.Map<IEnumerable<DenunciaModel>>(denunciasSelecionadas);
        }

        public long FiltrarEPaginarDenunciasQuantidade(ListarDenunciaGetModel model)
        {
            var filtro = _mapper.Map<Denuncia>(model);
            return _denunciaDomainService.FiltrarEPaginarDenunciasQuantidade(filtro);
        }

        public IEnumerable<DenunciaEstatisticaModel> ListarDenunciaEstatistica(Guid guid)
        {
            var denunciaEstatistica = _denunciaDomainService.ListarDenunciaEstatistica(guid);
            return _mapper.Map<IEnumerable<DenunciaEstatisticaModel>>(denunciaEstatistica);
        }

        public IEnumerable<DenunciaModel> ListarDenuncias()
        {
            var denuncias = _denunciaDomainService.ListarDenuncias();
            return _mapper.Map<IEnumerable<DenunciaModel>>(denuncias);
        }

        public IEnumerable<DenunciaModel> ListarDenunciasAprovadas()
        {
            var denunciasAprovada = _denunciaDomainService.ListarDenunciasAprovadas();
            return _mapper.Map<IEnumerable<DenunciaModel>>(denunciasAprovada);
        }

        public IEnumerable<DenunciaModel> ListarDenunciasUsuario(Guid guid)
        {
            var denunciasUsuario = _denunciaDomainService.ListarDenunciasUsuario(guid);
            return _mapper.Map<IEnumerable<DenunciaModel>>(denunciasUsuario);
        }

        public void MudarStatusDenuncia(Guid guid, StatusDenuncia model)
        {
            _denunciaDomainService.MudarStatusDenuncia(guid, model);
        }
    }
}

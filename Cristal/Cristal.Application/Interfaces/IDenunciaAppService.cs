using Cristal.Application.Models;
using Cristal.Domain.Enum;

namespace Cristal.Application.Interfaces
{
    public interface IDenunciaAppService
    {
        void CriarDenuncia(CriarDenunciaPostModel model);
        IEnumerable<DenunciaModel> ListarDenunciasAprovadas();
        IEnumerable<DenunciaEstatisticaModel> ListarDenunciaEstatistica(Guid guid);
        IEnumerable<DenunciaModel> ListarDenunciasUsuario(Guid guid);
        void ExcluirDenuncia(Guid guid);
        IEnumerable<DenunciaModel> FiltrarEPaginarDenuncias(ListarDenunciaGetModel model);
        long FiltrarEPaginarDenunciasQuantidade(ListarDenunciaGetModel model);
        void MudarStatusDenuncia(Guid guid, StatusDenuncia model);
        IEnumerable<DenunciaModel> ListarDenuncias();
        DenunciaModel AtualizarDenuncia(Guid guid, AtualizarDenunciaPutModel model);
    }
}

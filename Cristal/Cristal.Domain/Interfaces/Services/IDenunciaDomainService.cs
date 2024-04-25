using Cristal.Domain.Enum;
using Cristal.Domain.Models;

namespace Cristal.Domain.Interfaces.Services
{
    public interface IDenunciaDomainService
    {
        void CriarDenuncia(Denuncia denuncia);
        IEnumerable<Denuncia> ListarDenunciasAprovadas();
        IEnumerable<DenunciaEstatistica> ListarDenunciaEstatistica(Guid guid);
        IEnumerable<Denuncia> ListarDenunciasUsuario(Guid guid);
        void ExcluirDenuncia(Guid guid);
        IEnumerable<Denuncia> FiltrarEPaginarDenuncias(Denuncia filtro, int primeiroItem, int ultimoItem);
        long FiltrarEPaginarDenunciasQuantidade(Denuncia filtro);
        void MudarStatusDenuncia(Guid guid, StatusDenuncia model);
        IEnumerable<Denuncia> ListarDenuncias();
        Denuncia AtualizarDenuncia(Guid guid, Denuncia denuncia);
    }
}

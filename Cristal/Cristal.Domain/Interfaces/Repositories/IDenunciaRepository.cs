using Cristal.Domain.Models;

namespace Cristal.Domain.Interfaces.Repositories
{
    public interface IDenunciaRepository : IBaseRepository<Denuncia, Guid>
    {
        IEnumerable<Denuncia> ListarDenunciasAprovadas();
        IEnumerable<DenunciaEstatistica> ListarDenunciaEstatistica(Guid guid);
        IEnumerable<Denuncia> ListarDenunciasUsuario(Guid guid);
        IEnumerable<Denuncia> FiltrarEPaginarDenuncias(Denuncia filtro);
    }
}

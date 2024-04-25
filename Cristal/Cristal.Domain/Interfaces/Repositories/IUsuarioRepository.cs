using Cristal.Domain.Models;

namespace Cristal.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, Guid>
    {
        IEnumerable<Usuario> FiltrarEpaginarUsuarios(Usuario filtro);
    }
}

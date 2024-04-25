using Cristal.Domain.Interfaces.Repositories;
using Cristal.Domain.Models;
using Cristal.Infra.Data.Contexts;

namespace Cristal.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario, Guid>, IUsuarioRepository
    {
        public IEnumerable<Usuario> FiltrarEpaginarUsuarios(Usuario filtro)
        {
            using (var datacontext = new DataContext())
            {
                return datacontext.Set<Usuario>()
                    .Where(u => (string.IsNullOrEmpty(filtro.Nome) || u.Nome == filtro.Nome) &&
                                (string.IsNullOrEmpty(filtro.Email) || u.Email == filtro.Email)).ToList();
            }
        }
    }
}

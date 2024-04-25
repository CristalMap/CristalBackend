using Cristal.Domain.Interfaces.Repositories;
using Cristal.Domain.Models;
using Cristal.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Cristal.Infra.Data.Repositories
{
    public class DenunciaRepository : BaseRepository<Denuncia, Guid>, IDenunciaRepository
    {
        public IEnumerable<Denuncia> FiltrarEPaginarDenuncias(Denuncia filtro)
        {
            using (var datacontext = new DataContext())
            {
                return datacontext.Set<Denuncia>().Include(d => d.Endereco).Include(u => u.Usuario).Where(u =>
                (string.IsNullOrEmpty(filtro.Titulo) || u.Titulo == filtro.Titulo) && (filtro.Status == null || u.Status == filtro.Status)).ToList();
            }
        }

        public IEnumerable<DenunciaEstatistica> ListarDenunciaEstatistica(Guid guid)
        {
            using (var datacontext = new DataContext())
            {
                var estatisticaDenuncia = datacontext.Set<Denuncia>().Where(d => d.GuidUsuario == guid).GroupBy(d => d.Status).Select(d =>
                new DenunciaEstatistica { Status = d.Key, Quantidade = d.Count() }).ToList();

                return estatisticaDenuncia;
            }
        }

        public IEnumerable<Denuncia> ListarDenunciasAprovadas()
        {
            using (var datacontext = new DataContext())
            {
                return datacontext.Set<Denuncia>().Include(d => d.Endereco).Where(d => d.Status == Domain.Enum.StatusDenuncia.Aprovada).ToList();
            }
        }

        public IEnumerable<Denuncia> ListarDenunciasUsuario(Guid guid)
        {
            using (var datacontext = new DataContext())
            {
                return datacontext.Set<Denuncia>().Include(d => d.Endereco).Where(d => d.GuidUsuario == guid).ToList();
            }
        }
    }
}

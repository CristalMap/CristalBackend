using Cristal.Domain.Interfaces.Repositories;
using Cristal.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Cristal.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        public virtual void Add(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(entity);
                dataContext.SaveChanges();
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(entity);
                dataContext.SaveChanges();
            }
        }

        public virtual TEntity Find(TKey key)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().Find(key);
            }
        }

        public virtual TEntity Find(Func<TEntity, bool> where)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().FirstOrDefault(where);
            }
        }

        public virtual List<TEntity> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().ToList();
            }
        }

        public virtual List<TEntity> GetAll(Func<TEntity, bool> where)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<TEntity>().Where(where).ToList();
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }
        }
    }
}

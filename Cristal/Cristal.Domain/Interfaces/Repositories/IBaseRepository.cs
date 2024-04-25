namespace Cristal.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Func<TEntity, bool> where);
        TEntity Find(TKey key);
        TEntity Find(Func<TEntity, bool> where);
    }
}

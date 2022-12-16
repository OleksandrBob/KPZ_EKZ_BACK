using System.Linq.Expressions;

namespace Cars.Core.Repository
{
    public interface IRepository<TEntity>
    {
        int GetCount(Expression<Func<TEntity, bool>> filter);

        void Add(TEntity entityToAdd);

        List<TEntity> GetBy(Expression<Func<TEntity, bool>> filter);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}

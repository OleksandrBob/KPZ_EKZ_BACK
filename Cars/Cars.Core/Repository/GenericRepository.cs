using DAL;
using System.Linq.Expressions;

namespace Cars.Core.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private MyAppContext _context { get; set; }

        public GenericRepository(MyAppContext context)
        {
            _context = context;
        }

        public void Add(TEntity entityToAdd)
        {
            _context.Set<TEntity>()
                .Add(entityToAdd);

            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>()
                .Update(entity);

            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>()
                .Remove(entity);

            _context.SaveChanges();
        }

        public List<TEntity> GetBy(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>()
                .Where(filter)
                .ToList();
        }

        public int GetCount(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>()
                .Count(filter);
        }
    }
}

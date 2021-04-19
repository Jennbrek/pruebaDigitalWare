using DAL.DataContext;
using DAL.Repository.Contract;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Any(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Any(expression);
        }

        public void Create(TEntity entity)
        {
            _ = _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity Find(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> FindAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public ValueTask<TEntity> FindAsync(object id)
        {
            return _context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(expression);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}

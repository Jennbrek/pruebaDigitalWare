using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository.Contract
{
    public interface IRepositoryBase<TEntity>
    {
        TEntity Find(object id);
        ValueTask<TEntity> FindAsync(object id);
        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        bool Any(Expression<Func<TEntity, bool>> expression);
        void Save();
        Task<int> SaveAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StoreManagement.Data.Repositories.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(string uId);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<int> CommitAsync();
        void Dispose();
    }
}
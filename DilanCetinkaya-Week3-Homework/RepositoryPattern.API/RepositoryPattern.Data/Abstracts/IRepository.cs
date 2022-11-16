using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<bool> AddAsync(TEntity entity);
        bool Delete(TEntity entity);
        bool Update(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
    }
}

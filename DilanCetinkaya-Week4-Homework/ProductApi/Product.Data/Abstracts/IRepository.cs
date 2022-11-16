using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Data.Abstracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<int> AddAsync(TEntity entity);
        Task<int> Delete(int id);
        Task<int> Update(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
    }
}

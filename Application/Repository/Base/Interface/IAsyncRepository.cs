using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Base.Interface;

public interface IAsyncRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetAsync(int id); 
    Task UpdateAsync(TEntity entity);
    Task<TEntity> AddAsync(TEntity entity);
    Task<List<TEntity>> GetAllAsync();
}

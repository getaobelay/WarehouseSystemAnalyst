using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystemAnalyst.Interfaces.Base
{
    public interface IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        Task<object> GetNewId(object Id);
        Task<TEntity> GetByIdAsync(object Id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<bool> DeleteAsync(TEntity entityToDelete);
        Task<bool> DeleteAsync(object Id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entityToUpdate);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Interfaces.Base
{
    public interface IBaseRepository<TEntity>
        where TEntity : IBaseEntity, new()
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
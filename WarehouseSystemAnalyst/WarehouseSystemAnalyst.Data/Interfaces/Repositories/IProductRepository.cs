using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IProductRepository<TEntity> : IDataRepository<TEntity>
        where TEntity : IBaseEntity, new()
    {
    }
}
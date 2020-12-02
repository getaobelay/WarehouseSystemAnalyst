using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace arehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IWarehouseRepository<TSource, TDestension> : IBaseTransactionRepository<TSource, TDestension>
        where TSource : class, IBaseWarehouse, new()
        where TDestension : class, IBaseWarehouse, new()
    {
    }
}

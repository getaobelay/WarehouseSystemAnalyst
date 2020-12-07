using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace arehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IWarehouseRepository<TEntity> : IDataRepository<TEntity>
        where TEntity : class, IBaseWarehouse, new()
    {
        Task<TEntity> ReturnWarehouseItem(object Id, WarehouseItem item);
        Task<TEntity> MoveWarehouseItem(object Id, WarehouseItem item);
        Task<TEntity> UpdateAlloaction(object Id, Allocation allocation);
        Task<TEntity> ReturnAlloactionItem(object Id, WarehouseItem warehouseItems);
    }
}
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace arehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IStockRepository<TEntity> : IDataRepository<TEntity>
        where TEntity : class, IBaseStock, new()
    {
        Task<TEntity> UpdateWarehouseItem(object Id, WarehouseItem item);
        Task<TEntity> ReturnWarehouseItem(object Id, WarehouseItem warehouseItems);
        Task<TEntity> UpdateAlloaction(object Id, Allocation allocation);
        Task<TEntity> ReturnAlloactionItem(object Id, WarehouseItem warehouseItems);
    }
}
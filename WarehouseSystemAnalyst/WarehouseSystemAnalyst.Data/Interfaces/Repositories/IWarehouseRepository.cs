using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace arehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IWarehouseRepository<TSource, TDestination> : IBaseTransactionRepository<TSource, TDestination>
        where TSource : class, IBaseWarehouse, new()
        where TDestination : class, IBaseWarehouse, new()
    {
        Task<TSource> SourceItemsAvailability(string productId, string batchId, int Quantity);
        Task<TDestination> DestinationItemsAvailability(string productId, string batchId, int Quantity);
        Task<Transaction<TSource, TDestination>> TotalItemsAvailability(string productId, string batchId, int Quantity);
        Task<TDestination> MoveItemToDestination(string warehouseItemId);
        Task<TSource> MoveItemToSource<TSourceEntity>(string warehouseItemId);
    }
}

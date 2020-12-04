using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Base;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace arehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IWarehouseRepository<TSource, TDestination> : ITransactionRepository<TSource, TDestination>
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
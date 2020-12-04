using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Interfaces.Base;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IInventoryRepository<TSource, TDestination> : ITransactionRepository<TSource, TDestination>
        where TSource : class, IBaseStock, new()
        where TDestination : class, IBaseStock, new()
    {
        Task<TSource> SourceQuantityAvailability(string sourceId, string productId, string batchId, int quantity);
        Task<TDestination> DestinationQuantityAvailability(string destinationId, string productId, string batchId, int quantity);
        Task<Transaction<TSource, TDestination>> QuantityAvailability(string sourceId, string destinationId, string productId, string batchId, int quantity);
        Task<Transaction<TSource, TDestination>> UpdateQuantity(string sourceId, string destinationId, string productId, string batchId, int quantity);
        Task<Transaction<TSource, TDestination>> UpdateQuantity(TSource source, TDestination destination, int quantity);

    }
}
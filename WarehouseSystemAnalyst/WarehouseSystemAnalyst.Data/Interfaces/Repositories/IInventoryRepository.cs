using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IInventoryRepository<TSource, TDestination> : IBaseTransactionRepository1<TSource, TDestination>
        where TSource : class, IBaseStock, new()
        where TDestination : class, IBaseStock, new()
    {
        /// <summary>
        /// availability
        /// </summary>
        ///
        Task<TSource> SourceQuantityAvailability(string productId, string batchId, int Quantity);
        Task<TDestination> DestinationQuantityAvailability(string productId, string batchId, int Quantity);
        Task<Transaction<TSource, TDestination>> TotalQuantityAvailability(string productId, string batchId, int Quantity);
        Task<TDestinationEntity> MoveQuantityToDestination<TDestinationEntity>(string productId, string batchId, int Quantity)
            where TDestinationEntity : TDestination;
        Task<TSourceEntity> MoveQuantityToSource<TSourceEntity>(string productId, string batchId, int Quantity)
            where TSourceEntity : TSource;
    }
}

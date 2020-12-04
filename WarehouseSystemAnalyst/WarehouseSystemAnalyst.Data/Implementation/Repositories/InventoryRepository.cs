using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Data.Implementation.Repositories
{
    public class InventoryRepository<TSource, TDestination> : BaseTransactionRepository<TSource, TDestination>,
        IInventoryRepository<TSource, TDestination>
        where TSource : class, IBaseStock, new()
        where TDestination : class, IBaseStock, new()
    {
        public InventoryRepository(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : base(unitOfWork.Context)
        {
        }

        public InventoryRepository(WarehouseDbContext context) : base(context)
        {
        }

        public async Task<TDestination> DestinationQuantityAvailability(string destinationId, string productId, string batchId, int quantity)
        {
            var destResult = await desteRepository.GetSingleQuery(filter: s => s.PK.Equals(destinationId, System.StringComparison.Ordinal)
                         && s.ProductID.Equals(productId, System.StringComparison.Ordinal)
                         && s.BatchID.Equals(batchId, System.StringComparison.Ordinal));

            if (destResult.ProductQuantity >= quantity && destResult.IsQuanityAvailable)
            {
                return destResult;
            }

            return default;
        }
        public async Task<Transaction<TSource, TDestination>> QuantityAvailability(string sourceId, string destinationId, string productId, string batchId, int quantity)
        {
            var source = await SourceQuantityAvailability(destinationId, productId, batchId, quantity);
            var destination = await DestinationQuantityAvailability(destinationId, productId, batchId, quantity);

            return await Task.FromResult(Transaction.Found(source, destination));
        }
        public async Task<TSource> SourceQuantityAvailability(string sourceId, string productId, string batchId, int quantity)
        {
            var sourceResult = await sourceRepository.GetSingleQuery(filter: s => s.PK.Equals(sourceId, System.StringComparison.Ordinal)
              && s.ProductID.Equals(productId, System.StringComparison.Ordinal)
              && s.BatchID.Equals(batchId, System.StringComparison.Ordinal));

            if(sourceResult != null)
            {
                if (sourceResult.ProductQuantity >= quantity && sourceResult.IsQuanityAvailable)
                {
                    return sourceResult;
                }
            }

            return default;
        }
        public async Task<Transaction<TSource, TDestination>> UpdateQuantity(string sourceId, string destinationId, string productId, string batchId, int quantity)
        {
            try
            {
                var source = await SourceQuantityAvailability(sourceId, productId, batchId, quantity);
                if (source != null)
                {
                    var destination = await DestinationQuantityAvailability(destinationId, productId, batchId, quantity);
                    if (destination != null)
                    {
                        return await UpdateQuantity(source, destination, quantity);
                    }

                    return await Task.FromResult(Transaction.DestinationEmpty<TSource, TDestination>(source));
                }
                return await Task.FromResult(Transaction.Empty<TSource, TDestination>());
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Transaction<TSource, TDestination>> UpdateQuantity(TSource source, TDestination destination, int quantity)
        {
            if (source is null && destination is null)
            {
                throw new ArgumentNullException($"{nameof(source)}+{nameof(destination)}");
            }

            try
            {
                source.ProductQuantity -= quantity;
                source.BatchQuantity -= quantity;

                destination.ProductQuantity += quantity;
                destination.BatchQuantity += quantity;

                var sourceResults = await sourceRepository.UpdateAsync(source);
                var destResults = await desteRepository.UpdateAsync(destination);

                return await Task.FromResult(Transaction.Found(sourceResults, destResults));
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
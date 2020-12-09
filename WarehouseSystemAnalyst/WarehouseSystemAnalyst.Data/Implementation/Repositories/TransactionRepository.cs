﻿using arehouseSystemAnalyst.Data.Interfaces.Repositories;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Helpers;
using System.Collections.Generic;

namespace WarehouseSystemAnalyst.Data.Implementation.Repositories
{
    public class TransactionRepository<TSource, TDestination> : DataRepository<TSource>, ITransactionRepository<TSource, TDestination>
        where TSource : class, IBaseStock, new()
        where TDestination : class, IBaseStock, new()
    {
        private DataRepository<TDestination> destRepository;

        public TransactionRepository(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : base(unitOfWork)
        {
            destRepository = new DataRepository<TDestination>(UnitOfWork);

        }

        public TransactionRepository(WarehouseDbContext context) : base(context)
        {
        }

        public DataRepository<TDestination> DestRepository => destRepository ??= new DataRepository<TDestination>(UnitOfWork);

        public async Task<bool> DeleteAsync(TSource source, TDestination destination)
        {
            if (source is null)
            {
                throw new System.ArgumentNullException(nameof(source));
            }

            if (destination is null)
            {
                throw new System.ArgumentNullException(nameof(destination));
            }

            var sourceResult = await DeleteAsync(source);
            var destResult = await DestRepository.DeleteAsync(destination);

            return await Task.FromResult(sourceResult && destResult);
        }

        public async Task<TransactionResponse<TSource, TDestination>> DeleteAsync(object sourceId, object destinationId)
        {
            if (sourceId is null)
            {
                throw new System.ArgumentNullException(nameof(sourceId));
            }

            if (destinationId is null)
            {
                throw new System.ArgumentNullException(nameof(destinationId));
            }

            var source = await GetSingleQuery(s => s.PK == sourceId.ToString());
            var destination = await DestRepository.GetSingleQuery(s => s.PK == destinationId.ToString());

            if (source != null && destination != null)
            {
                var result = await DeleteAsync(source, destination);
                if (result)
                {
                    return await Task.FromResult(TransactionResponse.Success<TSource, TDestination>(default, default));
                }
            }

            return await Task.FromResult(TransactionResponse.Error<TSource, TDestination>(new List<string>() { "Failed to Delete" }));


        }

        public async Task<TransactionResponse<TSource, TDestination>> InsertAsync(TSource source, TDestination destination)
        {
            if (source is null)
            {
                throw new System.ArgumentNullException(nameof(source));
            }

            if (destination is null)
            {
                throw new System.ArgumentNullException(nameof(destination));
            }

            var sourceResult = await InsertAsync(source);
            var destResult = await destRepository.InsertAsync(destination);

            if (sourceResult != null || destResult != null)
            {
                return await Task.FromResult(TransactionResponse.Error<TSource, TDestination>(new List<string>() { "Failed to Create" }));
            }

            return await Task.FromResult(TransactionResponse.Success(sourceResult, destResult));
        }

        public async Task<TransactionResponse<TSource, TDestination>> UpdateAsync(TSource source, TDestination destination)
        {
            if (source is null)
            {
                throw new System.ArgumentNullException(nameof(source));
            }

            if (destination is null)
            {
                throw new System.ArgumentNullException(nameof(destination));
            }

            var sourceResult = await UpdateAsync(source);
            var destResult = await destRepository.UpdateAsync(destination);

            if (sourceResult != null || destResult != null)
            {
                return await Task.FromResult(TransactionResponse.Error<TSource, TDestination>(new List<string>() { "Failed to update" }));
            }

            return await Task.FromResult(TransactionResponse.Success(sourceResult, destResult));

        }


    }
}

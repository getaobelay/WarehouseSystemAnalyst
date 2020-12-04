using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Base;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Data.Implementation.BaseRepositories
{
    /// <summary>
    /// Base repository for handling base type entities
    /// </summary>
    /// <typeparam name="TSource">Source of type entity</typeparam>
    /// <typeparam name="TDestination">Destination of type entity</typeparam>
    public abstract class BaseTransactionRepository<TSource, TDestination> : ITransactionRepository<TSource, TDestination>
        where TDestination : class, IBaseEntity, new()
        where TSource : class, IBaseEntity, new()
    {
        internal DbSet<TSource> _sourceEntities { get; set; }
        internal DbSet<TDestination> _destinationEntities { get; set; }
        public IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; }
        public WarehouseDbContext Context { get; }

        public readonly IDataRepository<TSource> sourceRepository;
        public readonly IDataRepository<TDestination> desteRepository;

        public BaseTransactionRepository(
            IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : this(unitOfWork.Context)
        {
            UnitOfWork = unitOfWork;
            sourceRepository = new BaseDataRepository<TSource>(unitOfWork);
            desteRepository = new BaseDataRepository<TDestination>(unitOfWork);
            UnitOfWork = unitOfWork;
        }

        protected BaseTransactionRepository(WarehouseDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// This function gets all <typeparamref name="TSource"/> and <typeparamref name="TDestination"/> records
        /// </summary>
        /// <returns>ListTansaction populated with lists</returns>
        public async Task<ListTransaction<TSource, TDestination>> GetAllAsync()
        {
            var source = await sourceRepository.GetAllAsync();
            var destination = await desteRepository.GetAllAsync();

            return await Task.FromResult(ListTransaction.ListsFound(source, destination));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sourceFilter"><typeparamref name="TSource"/> expression</param>
        /// <param name="sourceOrderBy"><typeparamref name="TSource"/> order by expression</param>
        /// <param name="sourceIncludes"><typeparamref name="TSource"/> includes</param>
        /// <param name="destFilter"><typeparamref name="TDestination"/> expression</param>
        /// <param name="destOrderBy"><typeparamref name="TDestination"/> order by expression</param>
        /// <param name="destIncludes"><typeparamref name="TDestination"/> includes</param>
        /// <returns></returns>
        public async Task<ListTransaction<TSource, TDestination>> GetQueryAsync(Expression<Func<TSource, bool>> sourceFilter = null, Func<IQueryable<TSource>, IOrderedQueryable<TSource>> sourceOrderBy = null, string sourceIncludes = "", Expression<Func<TDestination, bool>> destFilter = null, Func<IQueryable<TDestination>, IOrderedQueryable<TDestination>> destOrderBy = null, string destIncludes = "")
        {
            var source = await sourceRepository.GetQuery(sourceFilter, sourceOrderBy, sourceIncludes);
            var destination = await desteRepository.GetQuery(destFilter, destOrderBy, destIncludes);

            return await Task.FromResult(ListTransaction.ListsFound(source, destination));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sourceFilter"></param>
        /// <param name="destFilter"></param>
        /// <param name="sourceIncludes"></param>
        /// <param name="destIncludes"></param>
        /// <returns></returns>
        public async Task<Transaction<TSource, TDestination>> GetSingleAsync(Expression<Func<TSource, bool>> sourceFilter, Expression<Func<TDestination, bool>> destFilter, string sourceIncludes = "", string destIncludes = "")
        {
            var source = await sourceRepository.GetSingleQuery(sourceFilter, sourceIncludes);
            var destination = await desteRepository.GetSingleQuery(destFilter, destIncludes);

            if (source != null && destination != null)
            {
                return await Task.FromResult(Transaction.Found(source, destination));
            }

            else if (source != null)
            {
                return await Task.FromResult(Transaction.DestinationEmpty<TSource, TDestination>(source));

            }

            else if (destination != null)
            {
                return await Task.FromResult(Transaction.SourceEmpty<TSource, TDestination>(destination));

            }

            return await Task.FromResult(Transaction.Empty<TSource, TDestination>());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public async Task<Transaction<TSource, TDestination>> InsertAsync(TSource source, TDestination destination)
        {
            var sourceResult = await sourceRepository.InsertAsync(source);
            var destResult = await desteRepository.InsertAsync(destination);

            if (sourceResult != null && destResult != null)
            {
                return await Task.FromResult(Transaction.Found(sourceResult, destResult));
            }

            return await Task.FromResult(Transaction.Found(sourceResult, destResult));
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public async Task<Transaction<TSource, TDestination>> UpdateAsync(TSource source, TDestination destination)
        {
            var sourceResult = await sourceRepository.UpdateAsync(source);
            var destinationResult = await desteRepository.UpdateAsync(destination);

            if (sourceResult != null && destinationResult != null)
            {
                return await Task.FromResult(Transaction.Found(sourceResult, destinationResult));
            }

            return await Task.FromResult(Transaction.Empty<TSource, TDestination>());
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sourceId"></param>
        /// <param name="destId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(object sourceId, object destId)
        {
            var sourceResult = await sourceRepository.DeleteAsync(sourceId);
            var destinationResult = await desteRepository.DeleteAsync(destId);

            if (sourceResult && destinationResult)
            {
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }


    }
}
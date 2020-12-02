using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Data.Implementation.BaseRepositories
{
    public class BaseTransactionRepository1<TSource, TDestination> : IBaseTransactionRepository1<TSource, TDestination>, IDisposable
        where TDestination : class, IBaseEntity, new()
        where TSource : class, IBaseEntity, new()
    {

        internal DbSet<TSource> _sourceEntities { get; set; }
        internal DbSet<TDestination> _destniationEntities { get; set; }

        private bool _isDisposed;
        protected BaseTransactionRepository1(
            IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : this(unitOfWork.Context)
        {

        }

        public BaseTransactionRepository1(WarehouseDbContext context)
        {
            _isDisposed = true;
            Context = context;
        }



        public WarehouseDbContext Context { get; set; }

        protected virtual DbSet<TSource> SourceEntities => _sourceEntities ??= Context.Set<TSource>();
        protected virtual DbSet<TDestination> DestensionEntities => _destniationEntities ??= Context.Set<TDestination>();

        public async void Dispose()
        {
            if (Context != null)
                await Context.DisposeAsync();
            _isDisposed = true;
        }
        public virtual async Task<bool> DeleteSourceAsync(object sourceId)
        {
            if (sourceId == null)
                throw new ArgumentNullException(nameof(sourceId));

            TSource sourceToDelete = await _sourceEntities.FindAsync(sourceId);

            if (sourceToDelete == null)
                throw new ArgumentNullException($"{nameof(sourceToDelete)}");

            if (Context == null || _isDisposed)
                Context = new WarehouseDbContext();

            return await DeleteSourceAsync(sourceToDelete);

        }
        public virtual async Task<bool> DeleteDestinationAsync(object destensionId)
        {
            if (destensionId == null)
                throw new ArgumentNullException(nameof(destensionId));

            TDestination destinationToDelete = await _destniationEntities.FindAsync(destensionId);

            if (destinationToDelete == null)
                throw new ArgumentNullException($"{nameof(destensionId)}");

            if (Context == null || _isDisposed)
                Context = new WarehouseDbContext();

            return await DeleteDestinationAsync(destinationToDelete);
        }
        public async virtual Task<bool> DeleteSourceAsync(TSource sourceToDelete)
        {
            if (sourceToDelete == null)
                throw new ArgumentNullException($"{nameof(sourceToDelete)}");

            if (sourceToDelete != null)
            {
                if (Context.Entry(sourceToDelete).State == EntityState.Detached)
                {
                    _sourceEntities.Attach(sourceToDelete);
                }
                _sourceEntities.Remove(sourceToDelete);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }
        public async virtual Task<bool> DeleteDestinationAsync(TDestination destinationToDelete)
        {
            if (destinationToDelete == null)
                throw new ArgumentNullException($"{nameof(destinationToDelete)}");

            if (destinationToDelete != null)
            {
                if (Context.Entry(destinationToDelete).State == EntityState.Detached)
                {
                    _destniationEntities.Attach(destinationToDelete);
                }
                _destniationEntities.Remove(destinationToDelete);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        public virtual async Task<ListTransaction<TSource, TDestination>> GetAllAsync()
        {
            return await Task.FromResult(ListTransaction.ListsFound(_sourceEntities, _destniationEntities));
        }
        public virtual async Task<ListTransaction<TSource, TDestination>> GetAllListQuery(Expression<Func<TDestination, bool>> destFilter = null, Func<IQueryable<TDestination>, IOrderedQueryable<TDestination>> destOrderBy = null, string destIncludes = "", Expression<Func<TSource, bool>> sourceFilter = null, Func<IQueryable<TSource>, IOrderedQueryable<TSource>> sourceOrderBy = null, string sourceIncludes = "")
        {
            var sourceQuery = await GetListQuery(sourceFilter, sourceOrderBy, sourceIncludes);
            var destQuery = await GetListQuery(destFilter, destOrderBy, sourceIncludes);

            if (sourceQuery != null && destQuery != null)
                return await Task.FromResult(ListTransaction.ListsFound(sourceQuery, destQuery));

            if (sourceQuery != null)
                return await Task.FromResult(ListTransaction.DestinationEmpty<TSource, TDestination>(sourceQuery));

            if (destQuery != null)
                return await Task.FromResult(ListTransaction.SourceEmpty<TSource, TDestination>(destination: destQuery));

            return await Task.FromResult(ListTransaction.ListsEmpty<TSource, TDestination>());
        }
        public virtual async Task<Transaction<TSource, TDestination>> GetSingleQuery(Expression<Func<TSource, bool>> sourceFilter, Expression<Func<TDestination, bool>> destFilter, string sourceIncludes = "", string destinationIncludes = "")
        {
            var source = await GetSingleQuery(sourceFilter, sourceIncludes);
            var destination = await GetSingleQuery(destFilter, destinationIncludes);

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

            else
            {
                return await Task.FromResult(Transaction.Empty<TSource, TDestination>());
            }
        }
        public virtual async Task<TSource> InsertAsync(TSource source)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<TDestination> InsertAsync(TDestination destension)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<Transaction<TSource, TDestination>> InsertAsync(TSource source, TDestination destension)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<TSource> UpdateAsync(TSource source)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<TDestination> UpdateAsync(TDestination destension)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<Transaction<TSource, TDestination>> UpdateAsync(TSource source, TDestination destension)
        {
            throw new NotImplementedException();
        }
        public virtual async Task<IEnumerable<TDestination>> GetListQuery(Expression<Func<TDestination, bool>> filter = null, Func<IQueryable<TDestination>, IOrderedQueryable<TDestination>> orderBy = null, string includes = "")
        {
            throw new NotImplementedException();
        }
        public virtual async Task<IEnumerable<TSource>> GetListQuery(Expression<Func<TSource, bool>> filter = null, Func<IQueryable<TSource>, IOrderedQueryable<TSource>> orderBy = null, string includes = "")
        {
            throw new NotImplementedException();
        }
        public virtual async Task<TSource> GetSingleQuery(Expression<Func<TSource, bool>> sourceFilter, string includes = "")
        {
            throw new NotImplementedException();
        }
        public virtual async Task<TDestination> GetSingleQuery(Expression<Func<TDestination, bool>> destFilter, string includes = "")
        {
            throw new NotImplementedException();
        }
        public Task<Transaction<TSource, TDestination>> GetSingleQuery(Expression<Func<TSource, bool>> sourceFilter, Expression<Func<TDestination, bool>> destFilter, string includes = "")
        {
            throw new NotImplementedException();
        }
    }
}

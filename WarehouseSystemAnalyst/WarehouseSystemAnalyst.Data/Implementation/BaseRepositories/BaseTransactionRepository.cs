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
    public class BaseTransactionRepository<TSource, TDestination> : IBaseTransactionRepository<TSource, TDestination>, IDisposable
        where TDestination : class, IBaseEntity, new()
        where TSource : class, IBaseEntity, new()
    {

        internal DbSet<TSource> _sourceEntities { get; set; }
        internal DbSet<TDestination> _destinationEntities { get; set; }

        private bool _isDisposed;
        protected BaseTransactionRepository(
            IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : this(unitOfWork.Context)
        {
            UnitOfWork = unitOfWork;
        }

        public BaseTransactionRepository(WarehouseDbContext context)
        {
            _isDisposed = true;
            Context = context;
        }

        public WarehouseDbContext Context { get; set; }
        protected virtual DbSet<TSource> SourceEntities => _sourceEntities ??= Context.Set<TSource>();
        protected virtual DbSet<TDestination> DestinationEntities => _destinationEntities ??= Context.Set<TDestination>();
        public IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; }

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

            try
            {
                TSource sourceToDelete = await _sourceEntities.FindAsync(sourceId);

                if (sourceToDelete == null)
                    throw new ArgumentNullException($"{nameof(sourceToDelete)}");

                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                return await DeleteSourceAsync(sourceToDelete);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public virtual async Task<bool> DeleteDestinationAsync(object destinationId)
        {
            if (destinationId == null)
                throw new ArgumentNullException(nameof(destinationId));

            try
            {
                TDestination destinationToDelete = await _destinationEntities.FindAsync(destinationId);

                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                return await DeleteDestinationAsync(destinationToDelete);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async virtual Task<bool> DeleteSourceAsync(TSource sourceToDelete)
        {
            if (sourceToDelete == null)
                throw new ArgumentNullException($"{nameof(sourceToDelete)}");

            try
            {
                if (Context.Entry(sourceToDelete).State == EntityState.Detached)
                {
                    _sourceEntities.Attach(sourceToDelete);
                }
                _sourceEntities.Remove(sourceToDelete);
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
                throw;
            }


        }
        public async virtual Task<bool> DeleteDestinationAsync(TDestination destinationToDelete)
        {
            if (destinationToDelete == null)
                throw new ArgumentNullException($"{nameof(destinationToDelete)}");

            try
            {
                if (Context.Entry(destinationToDelete).State == EntityState.Detached)
                {
                    _destinationEntities.Attach(destinationToDelete);
                }
                _destinationEntities.Remove(destinationToDelete);
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
                throw;
            }

        }
        public virtual async Task<ListTransaction<TSource, TDestination>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(ListTransaction.ListsFound(_sourceEntities, _destinationEntities));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public virtual async Task<ListTransaction<TSource, TDestination>> GetAllListQuery(Expression<Func<TDestination, bool>> destFilter = null, Func<IQueryable<TDestination>, IOrderedQueryable<TDestination>> destOrderBy = null, string destIncludes = "", Expression<Func<TSource, bool>> sourceFilter = null, Func<IQueryable<TSource>, IOrderedQueryable<TSource>> sourceOrderBy = null, string sourceIncludes = "")
        {
            try
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
            catch (Exception)
            {

                throw;
            }

        }
        public virtual async Task<TSource> InsertAsync(TSource source)
        {
            try
            {
                if (source == null)
                    throw new ArgumentNullException(nameof(source));

                await _sourceEntities.AddAsync(source);
                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                await UnitOfWork.SaveChangesAsync();
                return source;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public virtual async Task<TDestination> InsertAsync(TDestination destination)
        {
            try
            {
                if (destination == null)
                    throw new ArgumentNullException(nameof(destination));

                await _destinationEntities.AddAsync(destination);
                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                await UnitOfWork.SaveChangesAsync();
                return destination;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public virtual async Task<Transaction<TSource, TDestination>> InsertAsync(TSource source, TDestination destination)
        {
            try
            {
                if (source == null)
                    throw new ArgumentNullException(nameof(source));

                if (destination == null)
                    throw new ArgumentNullException(nameof(destination));

                await InsertAsync(destination);
                await InsertAsync(source);

                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                return await Task.FromResult(Transaction.Found(source, destination));
            }
            catch (Exception)
            {

                throw;
            }

        }
        public virtual async Task<TSource> UpdateAsync(TSource source)
        {
            try
            {
                if (source == null)
                    throw new ArgumentNullException(nameof(source));

                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                var sourceDbSet = Context.Set<TSource>();
                sourceDbSet.Attach(source);
                Context.Entry(source).State = EntityState.Modified;
                await UnitOfWork.SaveChangesAsync();
                return source;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<TDestination> UpdateAsync(TDestination destination)
        {
            try
            {
                if (destination == null)
                    throw new ArgumentNullException(nameof(destination));

                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                var sourceDbSet = Context.Set<TDestination>();
                sourceDbSet.Attach(destination);
                Context.Entry(destination).State = EntityState.Modified;
                await UnitOfWork.SaveChangesAsync();
                return destination;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public virtual async Task<Transaction<TSource, TDestination>> UpdateAsync(TSource source, TDestination destination)
        {
            try
            {
                if (source == null && destination == null)
                    throw new ArgumentNullException(nameof(source));

                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                if (source != null)
                {
                    if (destination != null)
                    {
                        return await Task.FromResult(Transaction.Found(await UpdateAsync(source), await UpdateAsync(destination)));
                    }
                    return await Task.FromResult(Transaction.DestinationEmpty<TSource, TDestination>(await UpdateAsync(source)));
                }

                return await Task.FromResult(Transaction.Empty<TSource, TDestination>());

            }
            catch (Exception)
            {
                return await Task.FromResult(Transaction.Empty<TSource, TDestination>());
            }
        }
        public virtual async Task<IEnumerable<TDestination>> GetListQuery(Expression<Func<TDestination, bool>> filter = null, Func<IQueryable<TDestination>, IOrderedQueryable<TDestination>> orderBy = null, string includes = "")
        {
            try
            {
                IQueryable<TDestination> query = _destinationEntities;

                if (filter != null)
                {
                    query = query.Where(filter);

                }

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(includes);
                    }
                }

                if (orderBy != null)
                {
                    return await Task.FromResult(query.ToList());
                }
                else
                {
                    return await Task.FromResult(await query.ToListAsync());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<IEnumerable<TSource>> GetListQuery(Expression<Func<TSource, bool>> filter = null, Func<IQueryable<TSource>, IOrderedQueryable<TSource>> orderBy = null, string includes = "")
        {
            try
            {
                IQueryable<TSource> query = _sourceEntities;

                if (filter != null)
                {
                    query = query.Where(filter);

                }

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        query = query.Include(includes);
                    }
                }

                if (orderBy != null)
                {
                    return await Task.FromResult(query.ToList());
                }
                else
                {
                    return await Task.FromResult(await query.ToListAsync());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<TSource> GetSingleQuery(Expression<Func<TSource, bool>> sourceFilter, string sourceIncludes = "")
        {
            try
            {
                TSource source = new TSource();

                if (sourceIncludes != null)
                {
                    source = await _sourceEntities.Where(sourceFilter).Include(sourceIncludes).SingleOrDefaultAsync();
                }

                else
                {
                    source = await _sourceEntities.Where(sourceFilter).SingleOrDefaultAsync();
                }

                return source;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<TDestination> GetSingleQuery(Expression<Func<TDestination, bool>> destFilter, string destIncludes = "")
        {
            try
            {
                if (destIncludes != null)
                {
                    return await _destinationEntities.Where(destFilter).Include(destIncludes).SingleOrDefaultAsync();
                }

                else
                {
                    return await _destinationEntities.Where(destFilter).SingleOrDefaultAsync();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<Transaction<TSource, TDestination>> GetSingleQuery(Expression<Func<TSource, bool>> sourceFilter, Expression<Func<TDestination, bool>> destFilter, string sourceIncludes = "", string destinationIncludes = "")
        {
            try
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
            catch (Exception)
            {

                throw;
            }

        }
    }
}

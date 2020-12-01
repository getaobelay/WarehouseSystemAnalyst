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
    public class BaseTransactionRepository<TSource, TDestension> : IBaseTransactionRepository<TSource, TDestension>, IDisposable
        where TDestension : class, IBaseEntity, new()
        where TSource : class, IBaseEntity, new()
    {

        internal DbSet<TSource> _sourceEntities { get; set; }
        internal DbSet<TDestension> _destensionEntities { get; set; }

        private bool _isDisposed;
        protected BaseTransactionRepository(
            IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : this(unitOfWork.Context)
        {

        }

        public BaseTransactionRepository(WarehouseDbContext context)
        {
            _isDisposed = true;
            Context = context;
        }
        public WarehouseDbContext Context { get; set; }

        protected virtual DbSet<TSource> SourceEntities => _sourceEntities ??= Context.Set<TSource>();
        protected virtual DbSet<TDestension> DestensionEntities => _destensionEntities ??= Context.Set<TDestension>();
        public virtual async Task<bool> DeleteAsync(TSource sourceToDelete = default, TDestension destensionToDelete = default)
        {
            if (sourceToDelete == null && destensionToDelete == null)
                throw new ArgumentNullException($"{nameof(sourceToDelete)}+{nameof(destensionToDelete)}");

            if (sourceToDelete != null)
            {
                if (Context.Entry(sourceToDelete).State == EntityState.Detached)
                {
                    _sourceEntities.Attach(sourceToDelete);
                }
                _sourceEntities.Remove(sourceToDelete);
                _destensionEntities.Remove(destensionToDelete);
            }

            else
            {
                if (Context.Entry(sourceToDelete).State == EntityState.Detached)
                {
                    _sourceEntities.Attach(sourceToDelete);
                }
                _sourceEntities.Remove(sourceToDelete);
                _destensionEntities.Remove(destensionToDelete);
            }

            return await Context.SaveChangesAsync() >= 1;

        }
        public virtual async Task<bool> DeleteAsync(object sourceId = default, object destensionId = default)
        {

            if (sourceId == null && destensionId == null)
                throw new ArgumentNullException(nameof(sourceId) + nameof(destensionId));

            TSource sourceToDelete = await _sourceEntities.FindAsync(sourceId);
            TDestension destToDelete = await _destensionEntities.FindAsync(destensionId);

            if (sourceToDelete == null && destToDelete == null)
                throw new ArgumentNullException($"{nameof(sourceToDelete) } + {nameof(sourceToDelete)}");

            else if (sourceToDelete != null && destToDelete != null)
            {
                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                return await DeleteAsync(sourceToDelete, destToDelete);
            }

            else if (sourceToDelete != null)
            {
                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                return await DeleteAsync(sourceToDelete);
            }

            else
            {
                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                return await DeleteAsync(destToDelete);
            }

        }
        public virtual async Task<ListTransaction<TSource, TDestension>> GetAllAsync()
        {
            return await Task.FromResult(Transaction.ListOk(_sourceEntities, _destensionEntities));
        }
        public virtual async Task<Transaction<TSource, TDestension>> InsertAsync(TSource source, TDestension destension)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (destension == null)
                throw new ArgumentNullException(nameof(destension));

            await _destensionEntities.AddAsync(destension);
            await _sourceEntities.AddAsync(source);

            if (Context == null || _isDisposed)
                Context = new WarehouseDbContext();

            return await Task.FromResult(Transaction.Ok(source, destension));
        }
        public async virtual Task<Transaction<TSource, TDestension>> UpdateAsync(TSource source, TDestension destension)
        {
            try
            {
                if (source == null)
                    throw new ArgumentNullException(nameof(source));

                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                var sourceDbSet = Context.Set<TSource>();
                var destDbSet = Context.Set<TDestension>();

                sourceDbSet.Attach(source);
                destDbSet.Attach(destension);

                Context.Entry(source).State = EntityState.Modified;
                Context.Entry(destension).State = EntityState.Modified;

                return await Task.FromResult(Transaction.Ok(source, destension));

            }
            catch (Exception)
            {
                return default;
            }
        }
        public virtual async Task<ListTransaction<TSource, TDestension>> GetListQuery(Expression<Func<TSource, bool>> sourceFilter = null, Expression<Func<TDestension, bool>> destFilter = null, Func<IQueryable<TSource>, IOrderedQueryable<TSource>> sourceOrderBy = null, Func<IQueryable<TDestension>, IOrderedQueryable<TDestension>> destOrderBy = null, string includes = "")
        {
            try
            {
                IQueryable<TSource> sourceQuery = _sourceEntities;
                IQueryable<TDestension> destQuery = _destensionEntities;

                if (destFilter != null && sourceFilter != null)
                {
                    sourceQuery = sourceQuery.Where(sourceFilter);
                    destQuery = destQuery.Where(destFilter);

                }

                else if (destFilter != null)
                {
                    sourceQuery = sourceQuery.Where(sourceFilter);

                }

                else if (sourceFilter != null)
                {
                    destQuery = destQuery.Where(destFilter);
                }

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        sourceQuery = sourceQuery.Include(includes);
                        destQuery = destQuery.Include(includes);

                    }
                }

                if (sourceOrderBy != null && destOrderBy != null)
                {
                    return await Task.FromResult(Transaction.ListOk(sourceQuery.ToList(), destQuery.ToList()));
                }
                else
                {
                    return await Task.FromResult(Transaction.ListOk(await sourceQuery.ToListAsync(), await destQuery.ToListAsync()));
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
                IQueryable<TSource> sourceQuery = _sourceEntities;

                if (filter != null)
                {
                    sourceQuery = sourceQuery.Where(filter);

                }

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        sourceQuery = sourceQuery.Include(includes);
                    }
                }

                if (orderBy != null)
                {
                    return await Task.FromResult(sourceQuery.ToList());
                }
                else
                {
                    return await Task.FromResult(await sourceQuery.ToListAsync());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<IEnumerable<TDestension>> GetListQuery(Expression<Func<TDestension, bool>> filter = null, Func<IQueryable<TDestension>, IOrderedQueryable<TDestension>> orderBy = null, string includes = "")
        {
            try
            {
                IQueryable<TDestension> destQuery = _destensionEntities;

                if (filter != null)
                {
                    destQuery = destQuery.Where(filter);

                }

                if (includes != null)
                {
                    foreach (var include in includes)
                    {
                        destQuery = destQuery.Include(includes);
                    }
                }

                if (orderBy != null)
                {
                    return await Task.FromResult(destQuery.ToList());
                }
                else
                {
                    return await Task.FromResult(await destQuery.ToListAsync());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual async Task<Transaction<TSource, TDestension>> GetSingleQuery(Expression<Func<TSource, bool>> sourceFilter, Expression<Func<TDestension, bool>> destFilter, string includes = "")
        {
            try
            {

                TSource source = await _sourceEntities.Where(sourceFilter).SingleOrDefaultAsync();
                if (source != null)
                {
                    TDestension dest = await _destensionEntities.Where(destFilter).SingleOrDefaultAsync();
                    if (dest != null)
                    {
                        return await Task.FromResult(Transaction.Ok(source, dest));
                    }

                    return await Task.FromResult(Transaction.DestinationEmpty<TSource, TDestension>(source));
                }

                return await Task.FromResult(Transaction.Empty<TSource, TDestension>());

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async void Dispose()
        {
            if (Context != null)
                await Context.DisposeAsync();
            _isDisposed = true;
        }

    }
}

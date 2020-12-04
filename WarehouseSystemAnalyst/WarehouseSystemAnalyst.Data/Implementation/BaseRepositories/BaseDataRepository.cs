using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Data.Implementation.BaseRepositories
{
    public class BaseDataRepository<TEntity> : IDataRepository<TEntity>, IDisposable
        where TEntity : class, IBaseEntity, new()
    {
        internal DbSet<TEntity> _entities { get; set; }
        private bool _isDisposed;

        public BaseDataRepository(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : this(unitOfWork.Context)
        {
            UnitOfWork = unitOfWork;
        }

        public BaseDataRepository(WarehouseDbContext context)
        {
            _isDisposed = true;
            Context = context;
        }

        public WarehouseDbContext Context { get; set; }

        protected virtual DbSet<TEntity> Entities => _entities ??= Context.Set<TEntity>();

        public IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(_entities);
        }

        public virtual async Task<TEntity> GetByIdAsync(object Id)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            return await _entities.FindAsync(Id);
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _entities.AddAsync(entity);
            if (Context == null || _isDisposed)
                Context = new WarehouseDbContext();

            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            if (entityToUpdate == null)
                throw new ArgumentNullException(nameof(entityToUpdate));

            if (Context == null || _isDisposed)
                Context = new WarehouseDbContext();

            var dbSet = Context.Set<TEntity>();
            dbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entityToUpdate;
        }

        public virtual async Task<bool> DeleteAsync(TEntity entityToDelete)
        {
            if (entityToDelete == null)
                throw new ArgumentNullException(nameof(entityToDelete));

            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _entities.Attach(entityToDelete);
            }

            _entities.Remove(entityToDelete);
            return await Context.SaveChangesAsync() >= 1;
        }

        public virtual async Task<bool> DeleteAsync(object Id)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            TEntity entityToDelete = await _entities.FindAsync(Id);

            if (entityToDelete == null)
                throw new ArgumentNullException(nameof(entityToDelete));
            else
            {
                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                return await DeleteAsync(entityToDelete);
            }
        }

        public virtual Task<object> GetNewId(object Id)
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            throw new NotImplementedException();
        }

        public async void Dispose()
        {
            if (Context != null)
                await Context.DisposeAsync();
            _isDisposed = true;
        }

        public virtual async Task<IEnumerable<TEntity>> GetQuery(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includes = "")
        {
            try
            {
                IQueryable<TEntity> query = _entities;

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
                    return orderBy(query).ToList();
                }
                else
                {
                    return await query.ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<TEntity> GetSingleQuery(Expression<Func<TEntity, bool>> filter, string includes = "")
        {
            throw new NotImplementedException();
        }
    }
}
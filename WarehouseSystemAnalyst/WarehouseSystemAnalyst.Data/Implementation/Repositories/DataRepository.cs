using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Data.Implementation.Repositories
{
    public class DataRepository<TEntity> : IDataRepository<TEntity>, IDisposable
        where TEntity : class, IBaseEntity, new()
    {
        private DbSet<TEntity> _entities;
        private bool _isDisposed;

        public DataRepository(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : this(unitOfWork.Context)
        {
            UnitOfWork = unitOfWork;
        }

        public DataRepository(WarehouseDbContext context)
        {

            _isDisposed = true;
            Context = context;
        }

        public WarehouseDbContext Context { get; set; }

        protected virtual DbSet<TEntity> Entities => _entities ??= Context.Set<TEntity>();

        public IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; }
        public virtual IQueryable<TEntity> Table
        {
            get { return Entities; }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(Entities);
        }

        public virtual async Task<TEntity> GetByIdAsync(object Id)
        {

            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            return await Entities.FindAsync(Id);
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            try
            {
                entity.CreatedBy = "tester";
                entity.ModifiedBy = "tester";

                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                await Entities.AddAsync(entity);
                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            try
            {
                if (entityToUpdate == null)
                    throw new ArgumentNullException(nameof(entityToUpdate));

                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                var dbSet = Context.Set<TEntity>();
                dbSet.Attach(entityToUpdate);
                Context.Entry(entityToUpdate).State = EntityState.Modified;

                return await Task.FromResult(entityToUpdate);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public virtual async Task<bool> DeleteAsync(TEntity entityToDelete)
        {
            try
            {
                if (entityToDelete == null)
                    throw new ArgumentNullException(nameof(entityToDelete));

                if (Context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    Entities.Attach(entityToDelete);
                }

                Entities.Remove(entityToDelete);
                return await Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public virtual async Task<bool> DeleteAsync(object Id)
        {
            try
            {
                if (Id == null)
                    throw new ArgumentNullException(nameof(Id));

                TEntity entityToDelete = await Entities.FindAsync(Id);

                if (entityToDelete == null)
                    throw new ArgumentNullException(nameof(entityToDelete));
                else
                {
                    if (Context == null || _isDisposed)
                        Context = new WarehouseDbContext();

                    return await DeleteAsync(entityToDelete);
                }
            }
            catch (Exception)
            {

                throw;
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
                IQueryable<TEntity> query = Entities;

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
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            try
            {

                if (includes != null)
                {
                    return await Entities.Where(filter).Include(includes).SingleOrDefaultAsync();
                }

                return await Entities.Where(filter).SingleOrDefaultAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Interfaces;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Data.Implementation
{
    public class DataRepository<TEntity> : IDataRepository<TEntity>, IDisposable
        where TEntity : class, IBaseEntity, new()
    {
        private DbSet<TEntity> _entities;
        private bool _isDisposed;

        public DataRepository(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork)
            : this(unitOfWork.Context)
        {
            UnitOfWork = unitOfWork;
        }

        public DataRepository(WarehouseDbContext context)
        {
            _isDisposed = true;
            Context = context;
        }

        public virtual WarehouseDbContext Context { get; set; }

        /// <summary>
        ///
        /// </summary>
        protected virtual DbSet<TEntity> Entities => _entities ??= Context.Set<TEntity>();

        /// <summary>
        ///
        /// </summary>
        public virtual IQueryable<TEntity> Table => Entities;

        public virtual IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    await Entities.AddAsync(entity);

                    if (Context == null || _isDisposed)
                        Context = new WarehouseDbContext();

                    return entity;
                }
                else
                    throw new ArgumentNullException("object is not set");
            }
            catch (Exception)
            {

                throw;
            }


        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task BulkInsertAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("object is not set");
            }
            else
            {
                using (var entity = entities.GetEnumerator())
                {
                    while (entity.MoveNext())
                    {
                        Context.Entry(entity.Current).State = EntityState.Added;
                    }
                }

                Context.Set<TEntity>().AddRange(entities);
                await Context.SaveChangesAsync();
            }

        }

        public virtual async void Dispose()
        {
            if (Context != null)
                await Context.DisposeAsync();
            _isDisposed = true;
        }

        [Obsolete]
        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Entities.Include(Context.GetIncludePaths(typeof(TEntity))).Where(expression).ToListAsync();
        }

        [Obsolete]
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(object Id) => await Entities.FindAsync(Id);

        public virtual async Task<TEntity> UpdateAsync(TEntity entityUpdate)
        {
            try
            {
                if (entityUpdate == null)
                    throw new ArgumentNullException($"{nameof(TEntity)} not found ");

                if (Context == null || _isDisposed)
                    Context = new WarehouseDbContext();

                Context.Entry(entityUpdate).State = EntityState.Modified;

                return await Task.FromResult(entityUpdate);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException();
            }
        }

        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Entities.Where(expression).SingleOrDefaultAsync();
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

                TEntity entityToDelete = await SingleOrDefaultAsync(e => e.PK == Id.ToString());

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

        public virtual async Task<TEntity> GetSingleQuery(Expression<Func<TEntity, bool>> filter, string includes = null)
        {
            IQueryable<TEntity> query = Entities;

            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            try
            {
                return await query.Where(filter).SingleOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
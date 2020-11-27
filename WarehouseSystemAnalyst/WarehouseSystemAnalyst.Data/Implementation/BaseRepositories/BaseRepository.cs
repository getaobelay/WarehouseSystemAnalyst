using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Data.Implementation.BaseRepositories
{
    public  class BaseRepository<TEntity> : IQueryRepository<TEntity>
        where TEntity : class, IBaseEntity, new()
    {
        private readonly Data.Context.WarehouseDbContext _context;
        internal DbSet<TEntity> _entities { get; set; }

        protected BaseRepository(Data.Context.WarehouseDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetQuery(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includes = "")
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
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            await Task.Delay(1);
            return _entities;
        }

        public virtual async Task<TEntity> GetByIdAsync(object Id)
        {
            return await _entities.FindAsync(Id);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            var dbSet = _context.Set<TEntity>();
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified ;
            await _context.SaveChangesAsync();
            return entityToUpdate;
        }

        public async Task<bool> DeleteAsync(TEntity entityToDelete)
        {

            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _entities.Attach(entityToDelete);
            }

            _entities.Remove(entityToDelete);
            return await _context.SaveChangesAsync() >= 1;
        }

        public async Task<bool> DeleteAsync(object Id)
        {
            TEntity entityToDelete = await _entities.FindAsync(Id);
            return await DeleteAsync(entityToDelete);
        }

        public Task<object> GetNewId(object Id)
        {
            throw new NotImplementedException();
        }
    }
}
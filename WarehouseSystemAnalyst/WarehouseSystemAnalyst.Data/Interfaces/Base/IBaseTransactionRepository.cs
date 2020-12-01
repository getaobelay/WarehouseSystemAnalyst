using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IBaseTransactionRepository<TSource, TDestension>
        where TSource : class, IBaseEntity, new()
        where TDestension : class, IBaseEntity, new()
    {
        Task<bool> DeleteAsync(object sourceId = null, object destensionId = null);
        Task<bool> DeleteAsync(TSource sourceToDelete = null, TDestension destensionToDelete = null);
        void Dispose();
        Task<ListTransaction<TSource, TDestension>> GetAllAsync();
        Task<IEnumerable<TDestension>> GetListQuery(Expression<Func<TDestension, bool>> filter = null, Func<IQueryable<TDestension>, IOrderedQueryable<TDestension>> orderBy = null, string includes = "");
        Task<IEnumerable<TSource>> GetListQuery(Expression<Func<TSource, bool>> filter = null, Func<IQueryable<TSource>, IOrderedQueryable<TSource>> orderBy = null, string includes = "");
        Task<ListTransaction<TSource, TDestension>> GetListQuery(Expression<Func<TSource, bool>> sourceFilter = null, Expression<Func<TDestension, bool>> destFilter = null, Func<IQueryable<TSource>, IOrderedQueryable<TSource>> sourceOrderBy = null, Func<IQueryable<TDestension>, IOrderedQueryable<TDestension>> destOrderBy = null, string includes = "");
        Task<Transaction<TSource, TDestension>> GetSingleQuery(Expression<Func<TSource, bool>> sourceFilter, Expression<Func<TDestension, bool>> destFilter, string includes = "");
        Task<Transaction<TSource, TDestension>> InsertAsync(TSource source, TDestension destension);
        Task<Transaction<TSource, TDestension>> UpdateAsync(TSource source, TDestension destension);
    }
}
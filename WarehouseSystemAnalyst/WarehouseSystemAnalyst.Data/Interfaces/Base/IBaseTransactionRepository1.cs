using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IBaseTransactionRepository1<TSource, TDestination>
        where TSource : class, IBaseEntity, new()
        where TDestination : class, IBaseEntity, new()
    {
        Task<bool> DeleteSourceAsync(object sourceId = null);
        Task<bool> DeleteDestinationAsync(object destensionId);
        Task<bool> DeleteSourceAsync(TSource sourceToDelete);
        Task<bool> DeleteDestinationAsync(TDestination destinationToDelete);
        Task<ListTransaction<TSource, TDestination>> GetAllAsync();
        Task<IEnumerable<TDestination>> GetListQuery(Expression<Func<TDestination, bool>> filter = null, Func<IQueryable<TDestination>, IOrderedQueryable<TDestination>> orderBy = null, string includes = "");
        Task<IEnumerable<TSource>> GetListQuery(Expression<Func<TSource, bool>> filter = null, Func<IQueryable<TSource>, IOrderedQueryable<TSource>> orderBy = null, string includes = "");
        Task<ListTransaction<TSource, TDestination>> GetAllListQuery(Expression<Func<TDestination, bool>> destFilter = null, Func<IQueryable<TDestination>, IOrderedQueryable<TDestination>> destOrderBy = null, string destIncludes = "", Expression<Func<TSource, bool>> sourceFilter = null, Func<IQueryable<TSource>, IOrderedQueryable<TSource>> sourceOrderBy = null, string sourceIncludes = "");
        Task<Transaction<TSource, TDestination>> GetSingleQuery(Expression<Func<TSource, bool>> sourceFilter, Expression<Func<TDestination, bool>> destFilter, string includes = "");
        Task<TSource> GetSingleQuery(Expression<Func<TSource, bool>> sourceFilter, string includes = "");
        Task<TDestination> GetSingleQuery(Expression<Func<TDestination, bool>> destFilter, string includes = "");
        Task<TSource> InsertAsync(TSource source);
        Task<TDestination> InsertAsync(TDestination destension);
        Task<Transaction<TSource, TDestination>> InsertAsync(TSource source, TDestination destension);
        Task<TSource> UpdateAsync(TSource source);
        Task<TDestination> UpdateAsync(TDestination destension);
        Task<Transaction<TSource, TDestination>> UpdateAsync(TSource source, TDestination destension);
        void Dispose();
    }
}
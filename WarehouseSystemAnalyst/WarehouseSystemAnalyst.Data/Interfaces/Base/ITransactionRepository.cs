using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Interfaces.Base
{
    public interface ITransactionRepository<TSource, TDestination>
        where TSource : class, IBaseEntity, new()
        where TDestination : class, IBaseEntity, new()
    {
        Task<ListTransaction<TSource, TDestination>> GetAllAsync();
        Task<ListTransaction<TSource, TDestination>> GetQueryAsync(Expression<Func<TSource, bool>> sourceFilter = null, Func<IQueryable<TSource>, IOrderedQueryable<TSource>> sourceOrderBy = null, string sourceIncludes = "", Expression<Func<TDestination, bool>> destFilter = null, Func<IQueryable<TDestination>, IOrderedQueryable<TDestination>> destOrderBy = null, string destIncludes = "");
        Task<Transaction<TSource, TDestination>> GetSingleAsync(Expression<Func<TSource, bool>> sourceFilter, Expression<Func<TDestination, bool>> destFilter, string sourceIncludes = "", string destIncludes = "");
        Task<Transaction<TSource, TDestination>> InsertAsync(TSource source, TDestination destination);
        Task<Transaction<TSource, TDestination>> UpdateAsync(TSource source, TDestination destination);
        Task<bool> DeleteAsync(object sourceId, object destId);

    }
}

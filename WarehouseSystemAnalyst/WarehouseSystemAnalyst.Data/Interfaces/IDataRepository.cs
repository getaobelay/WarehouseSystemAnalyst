using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Interfaces
{
    public interface IDataRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : IBaseEntity, new()
    {
        Task<IEnumerable<TEntity>> GetQuery(Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includes = "");

        Task<TEntity> GetSingleQuery(Expression<Func<TEntity, bool>> filter, string includes = "");
    }
}
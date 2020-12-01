using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Base;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Interfaces.Repositories
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

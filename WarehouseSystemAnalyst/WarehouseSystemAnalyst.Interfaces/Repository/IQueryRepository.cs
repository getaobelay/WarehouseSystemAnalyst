using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Interfaces.Base;

namespace WarehouseSystemAnalyst.Interfaces.Repository
{
    public interface IQueryRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class, new()
    {
        Task<IEnumerable<TEntity>> GetQuery(Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includes = "");
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IProductRepository<TEntity> : IDataRepository<TEntity>
        where TEntity : IBaseEntity, new()
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace arehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IWarehouseRepository<TSource, TDestension> : IBaseTransactionRepository<TSource, TDestension>
        where TSource : class, IBaseWarehouse<WarehouseItem>, new()
        where TDestension : class, IBaseWarehouse<WarehouseItem>, new()
    {
    }
}

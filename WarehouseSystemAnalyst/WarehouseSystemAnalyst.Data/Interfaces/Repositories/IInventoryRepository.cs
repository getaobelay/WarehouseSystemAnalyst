using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IInventoryRepository<TSource, TDestension> : IBaseMissionRepository<TSource, TDestension>
        where TSource : IBaseStock, new()
        where TDestension : IBaseStock, new()
    {

    }
}

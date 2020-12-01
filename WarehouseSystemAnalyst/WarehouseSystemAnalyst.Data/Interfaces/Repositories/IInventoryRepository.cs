using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IInventoryRepository<TSource, TDestension> : IBaseTransactionRepository<TSource, TDestension>
        where TSource : class, IBaseStock, new()
        where TDestension : class, IBaseStock, new()
    {

    }
}

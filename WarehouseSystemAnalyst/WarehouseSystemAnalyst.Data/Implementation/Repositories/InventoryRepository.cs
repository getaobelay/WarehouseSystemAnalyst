using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Implementation.Repositories
{
    public class InventoryRepository<TSource, TDestension> :
        BaseMissionRepository<TSource, TDestension>
        where TSource : class, IBaseStock, new()
        where TDestension : class, IBaseStock, new()
    {
        protected InventoryRepository(Context.WarehouseDbContext context) : base(context)
        {
        }
    }
}

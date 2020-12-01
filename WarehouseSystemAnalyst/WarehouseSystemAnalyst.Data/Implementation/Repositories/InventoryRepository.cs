using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Data.DataContext;

namespace WarehouseSystemAnalyst.Data.Implementation.Repositories
{
    public class InventoryRepository<TSource, TDestension> :
        BaseTransactionRepository<TSource, TDestension>
        where TSource : class, IBaseStock, new()
        where TDestension : class, IBaseStock, new()
    {
        protected InventoryRepository(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : base(unitOfWork)
        {
        }

        public InventoryRepository(WarehouseDbContext context) : base(context)
        {
        }

    }
}

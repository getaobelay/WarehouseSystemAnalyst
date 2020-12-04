using arehouseSystemAnalyst.Data.Interfaces.Repositories;
using System;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Data.Implementation.Repositories
{
    public class WarehouseRepository<TSource, TDestension> :
        BaseTransactionRepository<TSource, TDestension>, IWarehouseRepository<TSource, TDestension>
        where TSource : class, IBaseWarehouse, new()
        where TDestension : class, IBaseWarehouse, new()
    {
        public WarehouseRepository(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : base(unitOfWork)
        {
        }

        public WarehouseRepository(WarehouseDbContext context) : base(context)
        {
        }

        public Task<TSource> SourceItemsAvailability(string productId, string batchId, int Quantity)
        {
            throw new NotImplementedException();
        }

        public Task<TDestension> DestinationItemsAvailability(string productId, string batchId, int Quantity)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction<TSource, TDestension>> TotalItemsAvailability(string productId, string batchId, int Quantity)
        {
            throw new NotImplementedException();
        }

        public Task<TDestension> MoveItemToDestination(string warehouseItemId)
        {
            throw new NotImplementedException();
        }

        public Task<TSource> MoveItemToSource<TSourceEntity>(string warehouseItemId)
        {
            throw new NotImplementedException();
        }
    }
}
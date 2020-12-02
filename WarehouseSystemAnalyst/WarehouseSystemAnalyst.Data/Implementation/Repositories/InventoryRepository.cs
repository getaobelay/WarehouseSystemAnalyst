using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Data.DataContext;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;

namespace WarehouseSystemAnalyst.Data.Implementation.Repositories
{
    public class InventoryRepository<TSource, TDestension> : BaseTransactionRepository1<TSource, TDestension>,
        IInventoryRepository<TSource, TDestension>
        where TSource : class, IBaseStock, new()
        where TDestension : class, IBaseStock, new()
    {
        private readonly IUnitOfWorkRepository<WarehouseDbContext> unitOfWork;

        protected InventoryRepository(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public InventoryRepository(WarehouseDbContext context) : base(context)
        {
        }

        public Task<TSource> SourceQuantityAvailability(string productId, string batchId, int Quantity)
        {
            throw new System.NotImplementedException();
        }

        public Task<TDestension> DestinationQuantityAvailability(string productId, string batchId, int Quantity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Transaction<TSource, TDestension>> TotalQuantityAvailability(string productId, string batchId, int Quantity)
        {
            throw new System.NotImplementedException();
        }

        public Task<TDestinationEntity> MoveQuantityToDestination<TDestinationEntity>(string productId, string batchId, int Quantity) where TDestinationEntity : TDestension
        {
            throw new System.NotImplementedException();
        }

        public Task<TSourceEntity> MoveQuantityToSource<TSourceEntity>(string productId, string batchId, int Quantity) where TSourceEntity : TSource
        {
            throw new System.NotImplementedException();
        }
    }
}

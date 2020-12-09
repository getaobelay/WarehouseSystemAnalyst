using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Data.Context
{
    public class DataContext : IDataContext
    {
        public DataContext(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; set; }
        public ICurrentUser currentUser { get; set; }
    }
}

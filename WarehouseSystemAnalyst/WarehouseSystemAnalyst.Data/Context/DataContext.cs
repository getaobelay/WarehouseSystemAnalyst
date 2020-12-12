using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Data.Context
{
    public class DataContext : IDataContext
    {
        public DataContext(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork, ICurrentUser currentUser)
        {
            UnitOfWork = unitOfWork;
            CurrentUser = currentUser;
        }
        public IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; set; }
        public ICurrentUser CurrentUser { get; set; }
    }
}

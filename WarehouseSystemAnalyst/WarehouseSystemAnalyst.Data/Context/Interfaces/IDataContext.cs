using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Responses
{
    public interface IDataContext
    {
        IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; set; }
        ICurrentUser currentUser { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Responses
{
    public interface IDataContext<Context, TEntity>
        where TEntity : class, IBaseEntity, new()
        where Context : DbContext, new()
    {
        IUnitOfWorkRepository<Context> UnitOfWork { get; set; }
    }
}
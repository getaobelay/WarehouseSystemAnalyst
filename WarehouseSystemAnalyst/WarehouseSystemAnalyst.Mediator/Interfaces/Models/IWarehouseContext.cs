using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Data.Interfaces.Base;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;


namespace WarehouseSystemAnalyst.Mediator.Interfaces.Models
{
    public interface IWarehouseContext<Context, TModel>
        where TModel : class, IBaseEntity, new()
        where Context : DbContext, new()
    {
        IUnitOfWorkRepository<Context> UnitOfWork { get; set; }
        IBaseRepository<TModel> Repository { get; set; }
    }
}

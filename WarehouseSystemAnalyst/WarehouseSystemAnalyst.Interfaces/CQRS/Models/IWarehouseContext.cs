using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Interfaces.Base;
using WarehouseSystemAnalyst.Interfaces.Repository;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Models
{
    public interface IWarehouseContext<Context, TModel>
        where TModel : class, new()
        where Context : DbContext, new()
    {
        IUnitOfWorkRepository<Context> UnitOfWork { get; set; }
        IBaseRepository<TModel> Repository { get; set; }
    }
}

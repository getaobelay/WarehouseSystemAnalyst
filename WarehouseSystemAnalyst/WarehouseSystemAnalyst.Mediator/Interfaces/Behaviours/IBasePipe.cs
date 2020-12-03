using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Interfaces.Models;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Behaviours
{

    public interface IBasePipe<TContext, TModel>
       where TContext : DbContext, new()
       where TModel : class, IBaseEntity, new()
    {
        public IWarehouseContext<TContext, TModel> Context { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Interfaces.CQRS.Models;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Behaviours
{

    public interface IBasePipe<TContext, TModel>
       where TContext : DbContext, new()
       where TModel : class, new()
    {
        public IWarehouseContext<TContext, TModel> Context { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Behaviours
{
    public interface IQuantityPipe<TContext, TModel> : IBasePipe<TContext, TModel>
        where TContext : DbContext, new()
        where TModel : class, IBaseEntity, new()
    {
    }
}
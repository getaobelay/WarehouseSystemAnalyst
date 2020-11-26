using Microsoft.EntityFrameworkCore;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Behaviours
{
    public interface ICommandPipe<TContext, TModel> : IBasePipe<TContext, TModel>
        where TContext : DbContext, new()
        where TModel : class, new()
    {
    }
}

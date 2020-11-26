using Microsoft.EntityFrameworkCore;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Behaviours
{

    public interface IUserActionPipe<TContext, TModel> : IBasePipe<TContext, TModel>
       where TContext : DbContext, new()
       where TModel : class, new()
    {

    }
}

using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Interfaces.CQRS.Models;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;

namespace WarehouseSystemAnalyst.Mediator.Queries.Handlers
{
    public class SingleQueryHandler<TEntity, TDto, TQuery, TContext> :
        IQueryHandlerWrapper<TQuery, TEntity, TContext>
        where TEntity : class, new()
        where TDto : class, new()
        where TContext : DbContext, new()
        where TQuery : class, IQueryWrapper<TEntity>, new()
    {
        public SingleQueryHandler(IWarehouseContext<TContext, TEntity> context)
        {
            Context = context;
        }

        public IWarehouseContext<TContext, TEntity> Context { get; set; }

        public async Task<IQueryResponse<TEntity>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var result = await Context.Repository.GetAllAsync();
            throw new System.NotImplementedException();
        }

    }
}

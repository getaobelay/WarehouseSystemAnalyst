using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Queries.Handlers
{
    public class SingleQueryHandler<TEntity, TDto, TQuery> :
        IQueryHandlerWrapper<TQuery, TEntity>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, new()
        where TQuery : class, IQueryWrapper<TEntity>, new()
    {
        public SingleQueryHandler(IWarehouseContext<WarehouseDbContext, TEntity> context)
        {
            WarehouseContext = context;
        }

        public IWarehouseContext<WarehouseDbContext, TEntity> WarehouseContext { get; set; }

        public async Task<IQueryResponse<TEntity>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var result = await WarehouseContext.Repository.GetAllAsync();
            throw new System.NotImplementedException();
        }
    }
}
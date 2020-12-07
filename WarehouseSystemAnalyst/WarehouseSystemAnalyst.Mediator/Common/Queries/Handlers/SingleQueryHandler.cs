using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Queries.Handlers
{
    public class SingleQueryHandler<TEntity, TDto, TQuery> : IRequestHandler<TQuery, IQueryResponse<TDto>>
        where TEntity : class, IBaseEntity, new()
        where TDto : BaseDto, new()
        where TQuery : class, IQueryRequest<TEntity, TDto>, new()
    {
        private IBaseRepository<TEntity> repository;

        public SingleQueryHandler(IDataContext<WarehouseDbContext, TEntity> context)
        {
            Context = context;
            repository = new DataRepository<TEntity>(Context.UnitOfWork);
        }

        public IDataContext<WarehouseDbContext, TEntity> Context { get; set; }

        public Task<IQueryResponse<TDto>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Implementation;
using WarehouseSystemAnalyst.Data.Interfaces;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Queries.Requests;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Helpers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Queries.Handlers
{
    public class ListQueryHandler<TEntity, TDto, TQuery> : IRequestHandler<TQuery, HandlerResponse<TDto>>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
        where TQuery : ListQueryRequest<TEntity, TDto>, new()
    {
        private IBaseRepository<TEntity> repository;

        public ListQueryHandler(IDataContext context)
        {
            Context = context;
            repository = new DataRepository<TEntity>(Context.UnitOfWork);
        }

        public IDataContext Context { get; set; }

        public async Task<HandlerResponse<TDto>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAllAsync();
            return HandlerResponse.ListResponse(MappingHelper.Mapper.Map<IEnumerable<TDto>>(result));
        }
    }
}
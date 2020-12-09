using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;
using WarehouseSystemAnalyst.Mediator.Mapping;
using WarehouseSystemAnalyst.Mediator.Queries.Requests.CommonRequests;
using WarehouseSystemAnalyst.Mediator.Queries.Responses.CommonResponses;

namespace WarehouseSystemAnalyst.Mediator.Queries.Handlers.CommonHandlers
{
    public class ListQueryHandler<TEntity, TDto, TQuery> : IRequestHandler<TQuery, ListQueryResponse<TDto>>
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

        public async Task<ListQueryResponse<TDto>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAllAsync();
            return new ListQueryResponse<TDto>()
            {
                Dtos = MappingHelper.Mapper.Map<IEnumerable<TDto>>(result)
            };
        }
    }
}
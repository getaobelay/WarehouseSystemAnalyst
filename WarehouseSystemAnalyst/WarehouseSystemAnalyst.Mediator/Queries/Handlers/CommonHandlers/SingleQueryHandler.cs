using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Implementation;
using WarehouseSystemAnalyst.Data.Interfaces;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;
using WarehouseSystemAnalyst.Mediator.Mapping;
using WarehouseSystemAnalyst.Mediator.Queries.Requests.CommonRequests;
using WarehouseSystemAnalyst.Mediator.Queries.Responses.CommonResponses;

namespace WarehouseSystemAnalyst.Mediator.Queries.Handlers.CommonHandlers
{
    public class SingleQueryHandler<TEntity, TDto, TQuery> : IRequestHandler<TQuery, SingleQueryResponse<TDto>>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
        where TQuery : SingleQueryRequest<TEntity, TDto>, new()
    {
        private IDataRepository<TEntity> repository;

        public SingleQueryHandler(IDataContext context)
        {
            Context = context;
            repository = new DataRepository<TEntity>(Context.UnitOfWork);
        }

        public IDataContext Context { get; set; }

        public async Task<SingleQueryResponse<TDto>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            SingleQueryResponse<TDto> response = null;

            var result = await repository.GetSingleQuery(q => q.PK == request.Id.ToString());
            if (result != null)
            {
                response.Dto = MappingHelper.Mapper.Map<TDto>(result);
                response.Error = false;
                return response;
            }
            else
            {
                response.Dto = null;
                response.ErrorMessages = new List<string>() { $"{typeof(TEntity)} With {request.Id} not Found" };
                return response;
            }
        }
    }
}
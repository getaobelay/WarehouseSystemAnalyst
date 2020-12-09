using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Responses;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Helpers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Requests;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Common.Queries.Handlers
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

            var result = await repository.GetSingleQuery(q=> q.PK == request.Id.ToString());
            if(result != null)
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
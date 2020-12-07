using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Helpers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;
using WarehouseSystemAnalyst.Mediator.Interfaces.Wrappers;

namespace WarehouseSystemAnalyst.Mediator.Common.Queries.Handlers
{
    public class ListQueryHandler<TEntity, TDto, TQuery> : IRequestHandler<TQuery, IListQueryResponse<TDto>>
        where TEntity : class, IBaseEntity, new()
        where TDto : BaseDto, new()
        where TQuery : class, IListQueryRequest<TEntity, TDto>, new()
    {
        private IBaseRepository<TEntity> repository;

        public ListQueryHandler(IDataContext<WarehouseDbContext, TEntity> context)
        {
            Context = context;
            repository = new DataRepository<TEntity>(Context.UnitOfWork);
        }

        public IDataContext<WarehouseDbContext, TEntity> Context { get; set; }

        public async Task<IListQueryResponse<TDto>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            IListQueryResponse<TDto> response = null;
            var result = await repository.GetAllAsync();
            response.ViewModelList = MappingHelper.Mapper.Map<IEnumerable<TDto>>(result);

            return response;
        }
    }
}
using MediatR;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Requests;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Wrappers
{
    public interface IQueryHandlerWrapper<TRequest, TDto, TEntity> : IRequestHandler<TRequest, IQueryResponse<TDto>>
        where TRequest : IQueryRequest<TEntity, TDto>
        where TDto : class, IBaseDto, new()
        where TEntity : class, IBaseEntity, new()
    {
        public IDataContext<WarehouseDbContext, TEntity> Context { get; set; }
    }
}
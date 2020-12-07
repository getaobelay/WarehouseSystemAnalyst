using MediatR;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Requests;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Wrappers
{
    public interface ICommandHandlerWrapper<TIn, TEntity, TDto> : IRequestHandler<TIn, ICommandResponse<TDto>>
        where TIn : IUpdateRequest<TEntity, TDto>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        IDataContext<WarehouseDbContext, TEntity> WarehouseContext { get; set; }
    }
}
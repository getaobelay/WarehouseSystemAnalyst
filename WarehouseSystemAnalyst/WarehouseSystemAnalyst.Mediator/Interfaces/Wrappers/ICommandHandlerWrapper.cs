using MediatR;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers
{
    public interface ICommandHandlerWrapper<TIn, TEntity, TDto> : IRequestHandler<TIn, ICommandResponse<TDto>>
        where TIn : ICommandRequest<TEntity, TDto>
        where TEntity : class, IBaseEntity, new()
        where TDto : BaseDto, new()
    {
        IDataContext<WarehouseDbContext, TEntity> WarehouseContext { get; set; }
    }
}
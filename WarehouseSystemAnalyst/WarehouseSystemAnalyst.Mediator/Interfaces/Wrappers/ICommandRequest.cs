using MediatR;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers
{
    public interface ICommandRequest<TEntity, TDto> : IRequest<ICommandResponse<TDto>>
        where TEntity : class, IBaseEntity, new()
        where TDto : BaseDto, new()
    {
        public object Id { get; set; }
        public TEntity Entity { get; set; }
    }
}
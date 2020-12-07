using MediatR;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.StockCommands.Requests
{
    public class CollectionRequest<TEntity, TDto> : IRequest<ICommandResponse<TDto>>
        where TEntity : class, IBaseWarehouse, new()
        where TDto : BaseDto, new()
    {
        public object Id { get; set; }
        public object AllocationId { get; set; }
        public string AssignedTo { get; set; }
    }
}
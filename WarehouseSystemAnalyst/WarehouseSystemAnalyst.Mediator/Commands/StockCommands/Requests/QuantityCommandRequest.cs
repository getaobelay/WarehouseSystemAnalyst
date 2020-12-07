using MediatR;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.StockCommands.Requests
{
    public class QuantityCommandRequest<TEntity, TDto> : IRequest<ICommandResponse<TDto>>
        where TEntity : class, IBaseStock, new()
        where TDto : BaseDto, new()
    {
        public object SourceId { get; set; }
        public object DestinationId { get; set; }
        public int Quantity { get; set; }
    }
}
using MediatR;
using WarehouseSystemAnalyst.Data.Helpers;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests
{
    public class DeleteTransctionCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto> : IRequest<TransactionResponse<TSourceDto, TDestDto>>
        where TSourceEntity : class, IBaseStock, new()
        where TSourceDto : class, IBaseStockDto, new()
        where TDestEntity : class, IBaseStock, new()
        where TDestDto : class, IBaseStockDto, new()
    {
        public object SourceId { get; set; }
        public object DestinationId { get; set; }
        public bool UpdateDastination { get; set; }
    }
}
using MediatR;
using WarehouseSystemAnalyst.Data.Helpers;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests
{
    public interface ITransactionCommand<TSourceEntity, TSourceDto, TTDestEntity ,TDestDto> : IRequest<TransactionResponse<TSourceDto, TDestDto>>
        where TSourceEntity : class, IBaseEntity, new()
        where TTDestEntity : class, IBaseEntity, new()
        where TSourceDto : class, IBaseDto, new()
        where TDestDto : class, IBaseDto, new()
    {
        public object SourceId { get; set; }
        public object DestinationId { get; set; }
        public bool UpdateDestination { get; set; }
    }
}

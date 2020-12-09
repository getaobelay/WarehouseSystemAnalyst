using MediatR;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Helpers;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests
{
    public interface ITransactionCommandRequest<TSourceEntity, TSourceDto, TDestEntity, TDestDto> : IRequest<TransactionResponse<TSourceDto, TDestDto>>
        where TSourceEntity : class, IBaseEntity, new()
        where TDestEntity : class, IBaseEntity, new()
        where TSourceDto : class, IBaseDto, new()
        where TDestDto : class, IBaseDto, new()
    {
        public object SourceId { get; set; }
        public object DestinationId { get; set; }
        public bool UpdateDestination { get; set; }
    }
}

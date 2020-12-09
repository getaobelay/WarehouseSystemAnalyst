using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests.InventoryRequests
{
    public class CreateInventoryCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto> :
        ITransactionCommandRequest<TSourceEntity, TSourceDto, TDestEntity, TDestDto>
        where TSourceEntity : class, IBaseStock, new()
        where TSourceDto : class, IBaseStockDto, new()
        where TDestEntity : class, IBaseStock, new()
        where TDestDto : class, IBaseStockDto, new()
    {
        public object SourceId { get; set; }
        public object DestinationId { get; set; }
        public TSourceDto Source { get; set; }
        public TDestDto Destination { get; set; }
        public string Name { get; set; }
        public bool UpdateDestination { get; set; }
    }
}
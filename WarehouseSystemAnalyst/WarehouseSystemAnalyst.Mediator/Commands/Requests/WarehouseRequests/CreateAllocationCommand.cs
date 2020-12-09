using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Dtos.SupplyChainEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests.WarehouseRequests
{
    public class CreateAllocationCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto> : ITransactionCommandRequest<TSourceEntity, TSourceDto, TDestEntity, TDestDto>
        where TSourceEntity : class, IBaseStock, new()
        where TSourceDto : class, IBaseStockDto, new()
        where TDestEntity : class, IBaseStock, new()
        where TDestDto : class, IBaseStockDto, new()
    {
        public object Id { get; set; }
        public OrderDto OrderDto { get; set; }
        public IEnumerable<WarehouseItemDto> WarehouseItems { get; set; }
        public object SourceId { get; set; }
        public object DestinationId { get; set; }
        public bool UpdateDestination { get; set; }
    }
}
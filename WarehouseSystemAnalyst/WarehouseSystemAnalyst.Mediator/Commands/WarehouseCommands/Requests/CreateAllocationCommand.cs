using MediatR;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Dtos.SupplyChainEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.WarehouseCommands.Requests
{
    public class CreateAllocationCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto> : ITransactionCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto>
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
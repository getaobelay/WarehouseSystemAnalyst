using MediatR;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Dtos.SupplyChainEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.StockCommands.Requests
{
    public class AlloactionRequest<TEntity, TDto> : IRequest<ICommandResponse<TDto>>
        where TEntity : class, IBaseWarehouse, new()
        where TDto : BaseDto, new()
    {
        public object Id { get; set; }
        public OrderDto OrderDto { get; set; }
        public IEnumerable<WarehouseItemDto> WarehouseItems { get; set; }
    }
}
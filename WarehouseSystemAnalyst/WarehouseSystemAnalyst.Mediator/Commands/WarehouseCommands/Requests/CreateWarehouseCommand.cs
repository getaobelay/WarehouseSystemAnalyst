using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.StockCommands.Requests
{
    public class CreateWarehouseCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto> : ITransactionCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto>
        where TSourceEntity : class, IBaseWarehouse, new()
        where TSourceDto : class, IBaseWarehouseDto, new()
        where TDestEntity : class, IBaseWarehouse, new()
        where TDestDto : class, IBaseWarehouseDto, new()
    {
        public object SourceId { get; set; }
        public object DestinationId { get; set; }
        public string Name { get; set; }
        public bool UpdateDestination { get; set; }
    }
}
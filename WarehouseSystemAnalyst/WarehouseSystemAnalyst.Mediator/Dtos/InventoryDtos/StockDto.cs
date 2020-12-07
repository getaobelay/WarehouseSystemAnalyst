using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.InventoryDtos
{
    public class StockDto : BaseStockDto, IMapFrom<Stock>
    {
        public IEnumerable<ShippingWarehouseDto> ShippingWarehouses { get; set; }
    }
}
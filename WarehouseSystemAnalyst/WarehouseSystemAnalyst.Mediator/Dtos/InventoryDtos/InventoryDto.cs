using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.InventoryDtos
{
    public class InventoryDto : BaseStockDto, IMapFrom<Inventory>
    {
        public IEnumerable<GoodsWarehouseDto> GoodsWarehouses { get; set; }
    }
}
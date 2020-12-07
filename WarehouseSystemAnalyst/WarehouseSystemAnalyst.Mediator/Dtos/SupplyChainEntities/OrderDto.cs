using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.PalletDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.SupplyChainEntities
{
    public class OrderDto : BaseDto, IMapFrom<Order>
    {
        public IEnumerable<AllocationDto> Allocations { get; set; }
        public IEnumerable<OrderPalletDto> OrderPallets { get; set; }
    }
}
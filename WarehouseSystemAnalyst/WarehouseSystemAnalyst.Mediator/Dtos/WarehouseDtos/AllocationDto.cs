using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Mediator.Dtos.SupplyChainEntities;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos
{
    public class AllocationDto : BaseDto, IMapFrom<Allocation>
    {
        public bool IsAvailable { get; set; }
        public bool IsCompleted { get; set; }
        public IEnumerable<WarehouseItemDto> WarehouseItems { get; set; }
        public OrderDto Order { get; set; }
    }
}
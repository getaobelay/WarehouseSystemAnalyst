using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.SupplyChainEntities;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.PalletDtos
{
    public class OrderPalletDto : BasePalletDto, IMapFrom<OrderPallet>
    {
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.SupplyChainEntities
{
    public class VendorDto : BaseDto, IMapFrom<Vendor>
    {
        public IEnumerable<ProductVendorDto> ProductVendors { get; set; }
    }
}
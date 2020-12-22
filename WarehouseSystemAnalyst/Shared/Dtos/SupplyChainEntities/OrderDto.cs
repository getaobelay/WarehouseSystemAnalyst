using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Shared.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Shared.Dtos.SupplyChainEntities
{
    public class OrderDto : IBaseDto, IMapFrom<Order>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IEnumerable<AllocationDto> Allocations { get; set; }

    }
}
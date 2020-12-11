using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.SupplyChainEntities;
using WarehouseSystemAnalyst.Mediator.Helpers;

namespace WarehouseSystemAnalyst.Mediator.Dtos.PalletDtos
{
    public class OrderPalletDto :  IBasePalletDto, IMapFrom<OrderPallet>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string SupplierPallet { get; set; }
        public string PalletNumber { get; set; }
        public string PalletCode { get; set; }
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
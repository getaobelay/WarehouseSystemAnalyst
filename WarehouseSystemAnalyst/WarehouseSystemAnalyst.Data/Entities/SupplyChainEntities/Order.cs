using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities
{
    public class Order : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string AllocationId { get; set; }
        public string OrderPalletId { get; set; }

        public ICollection<Allocation> Allocations { get; set; }
        public ICollection<OrderPallet> OrderPallets { get; set; }
    }
}
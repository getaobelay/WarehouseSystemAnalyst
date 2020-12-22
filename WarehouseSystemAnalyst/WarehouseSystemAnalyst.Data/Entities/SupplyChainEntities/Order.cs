using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;

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
        public virtual ICollection<Allocation> Allocations { get; set; }
    }
}
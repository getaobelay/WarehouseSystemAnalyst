using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;

namespace WarehouseSystemAnalyst.Data.Entities.StockEntites
{
    public class Inventory : IBaseStock
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsQuanityAvailable { get; set; }
        public decimal TotalUnitsQuantity { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal BatchQuantity { get; set; }
        public string ProductId { get; set; }
        public string BatchId { get; set; }

        public decimal UnitsInInventory { get; set; }
        public decimal UnitsInOrder { get; set; }
        public decimal ReorderLevel { get; set; }
        public string GoodsWarehousesId { get; set; }
        public string AllocationWarehouseId { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<Batch> Batches { get; set; } = new HashSet<Batch>();
        public virtual ICollection<GoodsWarehouse> GoodsWarehouses { get; set; } = new HashSet<GoodsWarehouse>();
        public virtual ICollection<AllocationWarehouse> AllocationWarehouses { get; set; } = new HashSet<AllocationWarehouse>();
    }
}
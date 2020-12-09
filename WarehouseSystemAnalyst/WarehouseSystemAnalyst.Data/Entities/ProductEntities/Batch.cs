using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities
{
    public class Batch : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductId { get; set; }
        public string InventoryId { get; set; }
        public string StockId { get; set; }
        public string ProductSupplierId { get; set; }
        public string PalletId { get; set; }
        public string WarehouseItemId { get; set; }
        public string ProductItemId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductItem ProductItem { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual ICollection<ProductPallet> Pallets { get; set; } = new HashSet<ProductPallet>();
        public virtual ICollection<ProductVendor> ProductSuppliers { get; set; } = new HashSet<ProductVendor>();
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; } = new HashSet<WarehouseItem>();
    }
}
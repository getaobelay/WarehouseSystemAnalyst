using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities
{
    public class Product : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string StockId { get; set; }
        public string InventoryId { get; set; }
        public string ProductItemId { get; set; }
        public string WarehouseItemId { get; set; }
        public string PalletId { get; set; }
        public string MesureId { get; set; }
        public string BatchId { get; set; }
        public string ProductVendorId { get; set; }
        public string ProductPackageId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual Inventory Inventory { get; set; }

        public virtual ICollection<ProductItem> ProductItems { get; set; } = new HashSet<ProductItem>();
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; } = new HashSet<WarehouseItem>();
        public virtual ICollection<ProductPallet> Pallets { get; set; } = new HashSet<ProductPallet>();
        public virtual ICollection<ProductMesures> Mesures { get; set; } = new HashSet<ProductMesures>();
        public virtual ICollection<Batch> Batches { get; set; } = new HashSet<Batch>();
        public virtual ICollection<ProductVendor> ProductVendors { get; set; } = new HashSet<ProductVendor>();
        public virtual ICollection<ProductPackages> ProductPackages { get; set; } = new HashSet<ProductPackages>();
    }
}
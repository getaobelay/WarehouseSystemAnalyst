using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using System;

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

        #region Keys

        public string CategoryAK { get; set; }
        public string StockAK { get; set; }
        public string InventoryAK { get; set; }
        public string ProductItemAK { get; set; }
        public string WarehouseItemAK { get; set; }
        public string PalletAK { get; set; }
        public string MesureAK { get; set; }
        public string BatchAK { get; set; }
        public string ProductVendorAK { get; set; }
        public string ProductPackageAK { get; set; }

        #endregion Keys
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
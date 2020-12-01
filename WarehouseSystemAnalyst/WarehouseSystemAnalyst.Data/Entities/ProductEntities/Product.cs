using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities
{
    public class Product : BaseProduct
    {
        public string ProductName { get; set; }

        #region Keys

        public string CategoryID { get; set; }
        public string SubCategoryID { get; set; }
        public string StockInID { get; set; }
        public string StockOutID { get; set; }
        public string ItemID { get; set; }
        public string PalletID { get; set; }
        public string MesureID { get; set; }
        public string BatchID { get; set; }
        public string ProductSupplierID { get; set; }
        public string ProductPackageID { get; set; }

        #endregion Keys

        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual StockIn StockIn { get; set; }
        public virtual StockOut StockOut { get; set; }

        public virtual ICollection<ProductItem> ProductItems { get; set; } = new HashSet<ProductItem>();
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; } = new HashSet<WarehouseItem>();
        public virtual ICollection<ProductPallet> Pallets { get; set; } = new HashSet<ProductPallet>();
        public virtual ICollection<ProductMesures> Mesures { get; set; } = new HashSet<ProductMesures>();
        public virtual ICollection<Batch> Batches { get; set; } = new HashSet<Batch>();
        public virtual ICollection<ProductSuppliers> ProductSuppliers { get; set; } = new HashSet<ProductSuppliers>();
        public virtual ICollection<ProductPackages> ProductPackages { get; set; } = new HashSet<ProductPackages>();
    }
}
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{
    public class Product : BaseProduct
    {
        public string ProductName { get; set; }

        #region Keys
        public string CategoryID { get; set; }
        public string SubCategoryID { get; set; }
        public string InventoryID { get; set; }
        public string StockID { get; set; }
        public string ItemID { get; set; }
        public string PalletID { get; set; }
        public string MesureID { get; set; }
        public string BatchID { get; set; }
        public string ProductSupplierID { get; set; }
        public string ProductPackageID { get; set; }

        #endregion

        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual StockIn Inventory { get; set; }
        public virtual StockOut Stock { get; set; }

        public virtual ICollection<ProductItem> Items { get; set; } = new HashSet<ProductItem>();
        public virtual ICollection<ProductPallet> Pallets { get; set; } = new HashSet<ProductPallet>();
        public virtual ICollection<ProductMesures> Mesures { get; set; } = new HashSet<ProductMesures>();
        public virtual ICollection<Batch> Batches { get; set; } = new HashSet<Batch>();
        public virtual ICollection<ProductSuppliers> ProductSuppliers { get; set; } = new HashSet<ProductSuppliers>();
        public virtual ICollection<ProductPackages> ProductPackages { get; set; } = new HashSet<ProductPackages>();
    }
}
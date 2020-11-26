using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;
using WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Batches = new HashSet<Batch>();
            ProductSuppliers = new HashSet<ProductSuppliers>();
            ProductPackages = new HashSet<ProductPackages>();
        }
        public string ProductName { get; set; }

        #region Keys
        public string CategoryID { get; set; }
        public string SubCategoryID { get; set; }
        public string InventoryID { get; set; }
        public string StockID { get; set; }
        public string MovementID { get; set; }
        public string PalletID { get; set; }
        public string MesureID { get; set; }
        public string BatchID { get; set; }
        public string ProductSupplierID { get; set; }
        public string ProductPackageID { get; set; }

        #endregion

        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Stock Stock { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
        public virtual ICollection<ProductPallet> Pallets { get; set; }
        public virtual ICollection<ProductMesures> Mesures { get; set; }
        public virtual ICollection<Batch> Batches { get; set; }
        public virtual ICollection<ProductSuppliers> ProductSuppliers { get; set; }
        public virtual ICollection<ProductPackages> ProductPackages { get; set; }
        public virtual ICollection<ProductTransaction> ProductTransactions { get; set; }
    }
}
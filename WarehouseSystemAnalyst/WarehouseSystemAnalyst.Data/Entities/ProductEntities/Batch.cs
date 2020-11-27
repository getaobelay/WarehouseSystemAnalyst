using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using System;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{
    public class Batch : BaseProduct
    {
        public string ProductID { get; set; }
        public string InventoryID { get; set; }
        public string StockID { get; set; }
        public string ProductSupplierID { get; set; }
        public string PalletID { get; set; }
        public string MovementID { get; set; }

        public virtual Product Product { get; set; }
        public virtual StockOut Stock { get; set; }
        public virtual StockIn Inventory { get; set; }
        public virtual ICollection<ProductPallet> Pallets { get; set; } = new HashSet<ProductPallet>();
        public virtual ICollection<ProductSuppliers> ProductSuppliers { get; set; } = new HashSet<ProductSuppliers>();
        public virtual ICollection<ProductItem> Items { get; set; } = new HashSet<ProductItem>();

    }
}
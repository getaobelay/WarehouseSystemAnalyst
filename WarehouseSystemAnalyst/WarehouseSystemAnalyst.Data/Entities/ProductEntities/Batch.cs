using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities
{
    public class Batch : BaseProduct
    {
        public string ProductID { get; set; }
        public string StockInID { get; set; }
        public string StockOutID { get; set; }
        public string ProductSupplierID { get; set; }
        public string PalletID { get; set; }
        public string WarehouseItemID { get; set; }
        public string ProductItemId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductItem ProductItem { get; set; }

        public virtual StockOut StockOut { get; set; }
        public virtual StockIn StockIn { get; set; }
        public virtual ICollection<ProductPallet> Pallets { get; set; } = new HashSet<ProductPallet>();
        public virtual ICollection<ProductSuppliers> ProductSuppliers { get; set; } = new HashSet<ProductSuppliers>();
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; } = new HashSet<WarehouseItem>();
    }
}
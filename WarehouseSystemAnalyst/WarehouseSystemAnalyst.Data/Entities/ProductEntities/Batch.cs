using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{
    public class Batch : BaseEntity
    {
        public string ProductID { get; set; }
        public string InventoryID { get; set; }
        public string StockID { get; set; }
        public string ProductSupplierID { get; set; }
        public string PalletID { get; set; }
        public string MovementID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual ICollection<ProductPallet> Pallets { get; set; }
        public virtual ICollection<ProductSuppliers> ProductSuppliers { get; set; }
        public virtual ICollection<Item> Items { get; set; }


        public Batch()
        {
            Pallets = new HashSet<ProductPallet>();
            ProductSuppliers = new HashSet<ProductSuppliers>();
            Items = new HashSet<Item>();

        }

    }
}
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;

namespace WarehouseSystemAnalyst.Data.Entities.StockEntites
{
    public class Inventory : BaseStock
    {
        public decimal UnitsInInventory { get; set; }
        public decimal UnitsInOrder { get; set; }
        public decimal ReorderLevel { get; set; }
        public string GoodsWarehousesAK { get; set; }
        public string AllocationWarehouseAK { get; set; }
        public ICollection<GoodsWarehouse> GoodsWarehouses { get; set; }
        public ICollection<AllocationWarehouse> AllocationWarehouses { get; set; }
    }
}
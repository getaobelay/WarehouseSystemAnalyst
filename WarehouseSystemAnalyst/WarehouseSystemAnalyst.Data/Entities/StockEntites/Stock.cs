using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;

namespace WarehouseSystemAnalyst.Data.Entities.StockEntites
{
    public class Stock : BaseStock
    {
        public decimal UnitsInStock { get; set; }
        public decimal ReorderLevel { get; set; }
        public string AllocationWarehouseAK { get; set; }
        public string ShippingWarehousesAK { get; set; }
        public ICollection<AllocationWarehouse> AllocationWarehouses { get; set; }
        public ICollection<ShippingWarehouse> ShippingWarehouses { get; set; }
    }
}
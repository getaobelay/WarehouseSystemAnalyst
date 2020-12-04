using WarehouseSystemAnalyst.Data.Entities.StockEntites;

namespace WarehouseSystemAnalyst.DataTests1.Models
{
    public static partial class TestModels
    {
        public static Inventory Inventory => new Inventory
        {
            PK = "Inventory1",
            IsQuanityAvailable = false,
            ReorderLevel = 0,
            TotalUnitsQuantity = 0,
            UnitsInOrder = 0,
            UnitsInInventory = 0,
            GoodsWarehousesAK = GoodsWarehouse.PK,
            AllocationWarehouseAK = AllocationWarehouse.PK,
        };

        public static Stock Stock => new Stock
        {
            PK = "Stock1",
            IsQuanityAvailable = false,
            ReorderLevel = 0,
            TotalUnitsQuantity = 0,
            ShippingWarehousesAK = ShippingWarehouse.PK,
            AllocationWarehouseAK = AllocationWarehouse.PK,
        };
    };
}
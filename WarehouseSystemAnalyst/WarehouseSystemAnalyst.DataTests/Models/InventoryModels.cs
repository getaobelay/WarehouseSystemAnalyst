using System.Collections.ObjectModel;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;

namespace WarehouseSystemAnalyst.DataTests1.Models
{
    public static partial class TestModels
    {
        public static Inventory Inventory => new Inventory
        {
            PK = "Inventory1",
            IsQuanityAvailable = false,
            ProductQuantity = 0,
            BatchQuantity = 0,
            ProductID = Product.PK,
            ReorderLevel = 0,
            TotalUnitsQuantity = 0,
            UnitsInOrder = 0,
            UnitsInInventory = 0,
            GoodsWarehousesAK = GoodsWarehouse.PK,
            AllocationWarehouseAK = AllocationWarehouse.PK,
            BatchID = Batch.PK
        };
        public static Stock Stock => new Stock
        {
            PK = "Stock1",
            IsQuanityAvailable = false,
            ProductQuantity = 0,
            BatchQuantity = 0,
            ProductID = Product.PK,
            ReorderLevel = 0,
            TotalUnitsQuantity = 0,
            UnitsInStock = 0,
            AllocationWarehouseAK = AllocationWarehouse.PK,
            ShippingWarehousesAK = ShippingWarehouse.PK,
            BatchID = Batch.PK,
        };
    }
}

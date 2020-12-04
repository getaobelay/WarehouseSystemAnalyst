using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;

namespace WarehouseSystemAnalyst.DataTests1.Models
{
    public static partial class TestModels
    {
        public static ProductPallet ProductPallet => new ProductPallet
        {
            PK = "ProductPallet1",
            BatcID = Batch.PK,
            PalletNumber = "Pallet1",
            PalletCode = "PalletCode1",
            ProductID = Product.PK
        };

        public static OrderPallet OrderPallet => new OrderPallet
        {
            PK = "OrderPallet",
            OrderId = Order.PK,
            PalletNumber = "OrderPallet1",
            PalletCode = "OrderPalletCode1"
        };
    }
}
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entities.PalletEntities
{
    public class ProductPallet : BasePallet
    {
        public string ProductID { get; set; }
        public string BatcID { get; set; }

        public Product Product { get; set; }
        public Batch Batch { get; set; }
    }
}
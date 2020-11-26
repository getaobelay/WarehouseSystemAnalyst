using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{
    public class ProductPallet : BasePallet
    {
        public string ProductID { get; set; }
        public string BatcID { get; set; }

        public Product Product { get; set; }
        public Batch Batch { get; set; }
    }
}

using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities
{
    public class ProductItem : BaseProduct
    {
        public string ProductName { get; set; }
        public decimal BuyPricePerUnit { get; set; }
        public decimal SellPricePerUnit { get; set; }
        public string Metrial { get; set; }
        public string ProductId { get; set; }
        public string BatcId { get; set; }
        public string Mesure { get; set; }

        public virtual Batch Batch { get; set; }
        public virtual Allocation Allocation { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<Mesure> UnitOfMeusre { get; set; } = new HashSet<Mesure>();
    }
}
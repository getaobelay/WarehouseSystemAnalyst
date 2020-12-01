using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities
{
    public class Mesure : BaseProduct
    {
        public string ProductMesureId { get; set; }
        public string ProductItemId { get; set; }
        public ICollection<ProductMesures> ProductMesures { get; set; } = new HashSet<ProductMesures>();
        public ICollection<ProductItem> ProductItems { get; set; } = new HashSet<ProductItem>();

    }
}
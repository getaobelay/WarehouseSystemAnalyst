using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities
{
    public class Package : BaseProduct
    {
        public string Type { get; set; }
        public string ProductPackageID { get; set; }
        public virtual ICollection<ProductPackages> ProductPackages { get; set; } = new HashSet<ProductPackages>();
    }
}
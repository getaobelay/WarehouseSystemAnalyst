using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{
    public class ProductPackages : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductID { get; set; }
        public string PackageID { get; set; }
        public string ItemID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Package Package { get; set; }
        public virtual ICollection<ProductItem> Items { get; set; } = new HashSet<ProductItem>();

    }
}
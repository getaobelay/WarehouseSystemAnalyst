using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities
{
    public class ProductPackages : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductId { get; set; }
        public string PackageId { get; set; }
        public string ProductItemId { get; set; }
        public string WarehouseItemId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Package Package { get; set; }
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; } = new HashSet<WarehouseItem>();
        public virtual ICollection<ProductItem> ProductItems { get; set; } = new HashSet<ProductItem>();
    }
}
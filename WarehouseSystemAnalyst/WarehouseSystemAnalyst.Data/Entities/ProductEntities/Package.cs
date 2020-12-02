using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities
{
    public class Package : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Type { get; set; }
        public string ProductPackageID { get; set; }
        public virtual ICollection<ProductPackages> ProductPackages { get; set; } = new HashSet<ProductPackages>();
    }
}
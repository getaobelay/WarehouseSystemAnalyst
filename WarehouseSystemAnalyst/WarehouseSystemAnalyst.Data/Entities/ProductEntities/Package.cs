using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{


    public class Package : BaseProduct
    {
        public string Type { get; set; }
        public string ProductPackageID { get; set; }
        public virtual ICollection<ProductPackages> ProductPackages { get; set; } = new HashSet<ProductPackages>();
    }
}
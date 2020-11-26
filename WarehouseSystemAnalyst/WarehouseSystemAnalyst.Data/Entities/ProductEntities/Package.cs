using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{


    public class Package : BaseEntity
    {
        public string Type { get; set; }
        public string ProductPackageID { get; set; }
        public virtual ICollection<ProductPackages> ProductPackages { get; set; }


        public Package()
        {
            ProductPackages = new HashSet<ProductPackages>();
        }
    }
}
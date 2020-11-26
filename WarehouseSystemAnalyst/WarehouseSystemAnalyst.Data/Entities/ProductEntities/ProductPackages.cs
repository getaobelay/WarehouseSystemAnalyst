using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{
    public class ProductPackages : BaseEntity
    {
        public string ProductID { get; set; }
        public string PackageID { get; set; }
        public string MovementID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Package Package { get; set; }
        public virtual ICollection<Movement> Movements { get; set; }

    }
}
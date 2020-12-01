using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entities.WarehouseEntites
{
    public class Allocation : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsCompleted { get; set; }

        public string ProductItemID { get; set; }
        public string WarehouseItemID { get; set; }
        public virtual ICollection<ProductItem> ProductItems { get; set; }
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }

        public string OrderID { get; set; }
        public virtual Order Order { get; set; }


    }
}
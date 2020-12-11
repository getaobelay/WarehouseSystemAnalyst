using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;

namespace WarehouseSystemAnalyst.Data.Entities.WarehouseEntites
{
    public class Location : IBaseEntity
    {
        public int Id { get; set; }
        public string? PK { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string LocationRow { get; set; }
        public string LocationColum { get; set; }
        public string LocationShelf { get; set; }
        public string AllocationWarehouseID { get; set; }
        public string GoodsWarehouseID { get; set; }
        public string ShippingWarehouseID { get; set; }
        public string WarehouseItemID { get; set; }

        //public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<AllocationWarehouse> AllocationWarehouses { get; set; }

        public virtual ICollection<GoodsWarehouse> GoodsWarehouses { get; set; }
        public virtual ICollection<ShippingWarehouse> ShippingWarehouses { get; set; }
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }
    }
}
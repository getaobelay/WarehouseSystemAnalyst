using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entites.WarehouseEntites
{
    public class Location : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int LocationPK { get; set; }
        public string LocationID { get; set; }
        public string LocationRow { get; set; }
        public string LocationColum { get; set; }
        public string LocationShelf { get; set; }
        public string WarehouseID { get; set; }
        public string ItemID { get; set; }

        //public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<ProductItem> Items { get; set; }
    }
}
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;

namespace WarehouseSystemAnalyst.Data.Interfaces.Models
{
    public interface IBaseWarehouse : IBaseEntity
    {
        public string WarehouseName { get; set; }
        public string WarehouseItemID { get; set; }
        public string LocationID { get; set; }

        public ICollection<WarehouseItem> WarehouseItems { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
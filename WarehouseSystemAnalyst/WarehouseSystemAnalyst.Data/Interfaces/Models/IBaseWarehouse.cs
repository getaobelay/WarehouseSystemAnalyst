using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;

namespace WarehouseSystemAnalyst.Data.Interfaces.Models
{
    public interface IBaseWarehouse<TItem> : IBaseEntity, IBaseItem
    {
        public string WarehouseName { get; set; }
        public string WarehouseItemID { get; set; }
        public string LocationID { get; set; }

        public ICollection<TItem> WarehouseItems { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;

namespace WarehouseSystemAnalyst.Data.Entites.WarehouseEntites
{
    public class Location
    {
        public Location()
        {
            Movements = new HashSet<Movement>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationPK { get; set; }
        public string LocationID { get; set; }
        public string LocationRow { get; set; }
        public string LocationColum { get; set; }
        public string LocationShelf { get; set; }
        public string WarehouseID { get; set; }
        public string MovementID { get; set; }

        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<Movement> Movements { get; set; }
    }
}
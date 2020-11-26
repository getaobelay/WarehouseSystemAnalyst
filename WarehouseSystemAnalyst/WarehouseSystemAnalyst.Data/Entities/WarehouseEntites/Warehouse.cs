using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites;

namespace WarehouseSystemAnalyst.Data.Entites.WarehouseEntites
{
    public class Warehouse
    {
        public Warehouse()
        {
            Transactions = new HashSet<WarehouseTransaction>();
            Locations = new HashSet<Location>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WarehousePK { get; set; }
        public string WarehouseID { get; set; }
        public string WarehouseName { get; set; }
        public string MovementID { get; set; }
        public string LocationID { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<WarehouseTransaction> Transactions { get; set; }
    }
}
using System;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites
{
    public class WarehouseTransaction : BaseTransaction
    {
        public string WarehouseID { get; set; }
        public string MovementID { get; set; }

        public virtual Warehouse Warehouse { get; set; }
        public virtual Movement Movement { get; set; }

    }
}

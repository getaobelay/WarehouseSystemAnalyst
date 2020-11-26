using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Entites.ProductEntities;
using System;

namespace WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites
{
    public class ProductTransaction : BaseTransaction
    {
        public string ProductID { get; set; }
        public string MovementID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Movement Movement { get; set; }
    }
}

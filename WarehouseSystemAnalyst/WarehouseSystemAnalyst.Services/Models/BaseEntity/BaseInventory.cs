using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entites.ProductEntities;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Models.Data.ProductModels;
using WarehouseSystemAnalyst.Data.Models.Data.WarehouseModels;

namespace WarehouseSystemAnalyst.Services.Models.BaseEntity
{
    public abstract class BaseInventory : IBaseInventory
    {
        public abstract bool IsQuanityAvailable { get; set; }
        public abstract int TotalUnitsQuantity { get; set; }
        public abstract int ProductQuantity { get; set; }
        public abstract int BatchQuantity { get; set; }
        public abstract string ProductID { get; set; }
        public abstract string BatchID { get; set; }
        public abstract string WarehouseID { get; set; }
        public abstract ICollection<Warehouse> Warehouses { get; set; }
        public abstract ICollection<Product> Products { get; set; }
        public abstract ICollection<Batch> Batches { get; set; }
        public abstract int Id { get; set; }
        public abstract string PK { get; set; }
        public abstract DateTime CreateDate { get; set; }
        public abstract DateTime ModifiedDate { get; set; }
        public abstract string CreatedBy { get; set; }
        public abstract string ModifiedBy { get; set; }
    }
}

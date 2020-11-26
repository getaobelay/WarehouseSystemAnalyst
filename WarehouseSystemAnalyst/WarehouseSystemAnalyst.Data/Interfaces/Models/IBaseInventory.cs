using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entites.ProductEntities;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;

namespace WarehouseSystemAnalyst.Data.Interfaces.Models
{
    public interface IBaseInventory : IBaseEntity
    {
        /// <summary>
        /// is available
        /// </summary>
        public bool IsQuanityAvailable { get; set; }
        public decimal TotalUnitsQuantity { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal BatchQuantity { get; set; }
        public string ProductID { get; set; }
        public string BatchID { get; set; }
        public string WarehouseID { get; set; }
        public ICollection<Warehouse> Warehouses { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Batch> Batches { get; set; }

    }
}

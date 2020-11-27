using System;
using WarehouseSystemAnalyst.Data.Entites.InventoryEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{
    public class ProductSuppliers : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductID { get; set; }
        public string BatchID { get; set; }

        public string SupplierID { get; set; }

        public Product Product { get; set; }
        public Batch Batch { get; set; }

        public virtual Supplier Suppliers { get; set; }
    }
}
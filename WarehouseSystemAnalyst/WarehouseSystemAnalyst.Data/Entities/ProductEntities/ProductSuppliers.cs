using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;
using WarehouseSystemAnalyst.Data.Entites.InventoryEntites;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{
    public class ProductSuppliers : BaseEntity
    {

        public string ProductID { get; set; }
        public string BatchID { get; set; }

        public string SupplierID { get; set; }

        public Product Product { get; set; }
        public Batch Batch { get; set; }

        public virtual Supplier Suppliers { get; set; }
    }
}
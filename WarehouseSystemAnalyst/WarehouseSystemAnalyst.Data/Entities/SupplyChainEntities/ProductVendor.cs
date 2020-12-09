using System;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities
{
    public class ProductVendor : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductId { get; set; }
        public string VendorId { get; set; }
        public Product Product { get; set; }
        public Batch Batch { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
using System;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;

namespace WarehouseSystemAnalyst.Data.Entities.PalletEntities
{
    public class ProductPallet : IBasePallet
    {
        public int Id { get; set; }
        public string? PK { get; set; }
        public string SupplierPallet { get; set; }
        public string PalletNumber { get; set; }
        public string PalletCode { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductId { get; set; }
        public string BatchId { get; set; }

        public virtual  Product Product { get; set; }
        public virtual Batch Batch { get; set; }
    }
}
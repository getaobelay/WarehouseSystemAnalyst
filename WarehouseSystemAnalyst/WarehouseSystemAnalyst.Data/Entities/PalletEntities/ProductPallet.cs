using System;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entities.PalletEntities
{
    public class ProductPallet : IBasePallet
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string SupplierPallet { get; set; }
        public string PalletNumber { get; set; }
        public string PalletCode { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductID { get; set; }
        public string BatcID { get; set; }

        public Product Product { get; set; }
        public Batch Batch { get; set; }
    }
}
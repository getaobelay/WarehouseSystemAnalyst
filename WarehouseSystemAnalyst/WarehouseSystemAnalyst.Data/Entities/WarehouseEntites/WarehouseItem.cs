using System;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entities.WarehouseEntites
{
    public class WarehouseItem : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string ProductID { get; set; }
        public string BatchID { get; set; }
        public string LocationID { get; set; }
        public string ProductPackageID { get; set; }
        public string EmployeeID { get; set; }
        public string ProductMesureId { get; set; }
        public string AllocationId { get; set; }
        public string AllocationWarehouseId { get; set; }
        public string GoodsWarehouseId { get; set; }
        public string ShippingWarhouseId { get; set; }

        public virtual Product Product { get; set; }

        public virtual AllocationWarehouse AllocationWarehouse { get; set; }
        public virtual GoodsWarehouse GoodsWarehouse { get; set; }
        public virtual ShippingWarehouse ShippingWarehouse { get; set; }
        public virtual ProductPackages ProductPackage { get; set; }
        public virtual Allocation Allocation { get; set; }
        public virtual ProductMesures ProductMesures { get; set; }
        public virtual Location Location { get; set; }
        public virtual Batch Batch { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
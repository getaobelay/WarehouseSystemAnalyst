using WarehouseSystemAnalyst.Data.Entites.ProductEntities;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using System;

namespace WarehouseSystemAnalyst.Data.Entites.WarehouseEntites
{
    public abstract class ProductItem : IBaseEntity
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string PalletNumber { get; set; }
        public string WarehouseID { get; set; }
        public string ProductID { get; set; }
        public string BatchID { get; set; }
        public string LocationID { get; set; }
        public string ProductPackageID { get; set; }
        public string EmployeeID { get; set; }
        public string UnitOfMesureID { get; set; }

        public Product Product { get; set; }
        //public Warehouse Warehouse { get; set; }
        public ProductPackages ProductPackage { get; set; }
        public ProductMesures UnitOfMesure { get; set; }
        public Location Location { get; set; }
        public Batch Batch { get; set; }
        public Employee Employee { get; set; }
    }
}

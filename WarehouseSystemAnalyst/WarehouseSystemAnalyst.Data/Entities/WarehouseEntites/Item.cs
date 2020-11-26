using System;
using WarehouseSystemAnalyst.Data.Entites.ProductEntities;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Entites.UserEntites;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites;

namespace WarehouseSystemAnalyst.Data.Entites.WarehouseEntites
{
    public abstract class Item : BaseEntity
    {
        public string PalletNumber { get; set; }
        public string WarehouseID { get; set; }
        public string ProductID { get; set; }
        public string BatchID { get; set; }
        public string LocationID { get; set; }
        public string ProductPackageID { get; set; }
        public string EmployeeID { get; set; }
        public string UnitOfMesureID { get; set; }

        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
        public ProductPackages ProductPackage { get; set; }
        public ProductMesures UnitOfMesure { get; set; }
        public Location Location { get; set; }
        public Batch Batch { get; set; }
        public Employee Employee { get; set; }

        public virtual ICollection<EmployeeTransaction> EmployeeTransactions { get; set; }
        public virtual ICollection<ProductTransaction> ProductTransactions { get; set; }
        public virtual ICollection<WarehouseTransaction> WarehouseTransactions { get; set; }

    }
}

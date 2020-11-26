using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites;
using WarehouseSystemAnalyst.Data.Entites.ProductEntities;
using WarehouseSystemAnalyst.Data.Entites.UserEntites;

namespace WarehouseSystemAnalyst.Data.Entites.WarehouseEntites
{
    public class Movement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovementPK { get; set; }
        public string MovementID { get; set; }
        public string PalletNumber { get; set; }
        public int Quantity { get; set; }

        public string WarehouseID { get; set; }
        public string ProductID { get; set; }
        public string BatchID { get; set; }
        public string LocationID { get; set; }
        public string ProductPackageID { get; set; }
        public string EmployeeID { get; set; }

        public virtual Warehouse Warehouse { get; set; }
        public virtual Product Product { get; set; }
        public virtual Location Location { get; set; }
        public virtual ProductPackages ProductPackage { get; set; }
        public virtual Batch Batch { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<EmployeeTransaction> EmployeeTransactions { get; set; }
        public virtual ICollection<ProductTransaction> ProductTransactions { get; set; }
        public virtual ICollection<WarehouseTransaction> WarehouseTransactions { get; set; }

    }
}
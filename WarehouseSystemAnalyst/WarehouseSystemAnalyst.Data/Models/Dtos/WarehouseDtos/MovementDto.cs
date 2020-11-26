using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites;
using WarehouseSystemAnalyst.Data.Entites.UserEntites;
using WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.WarehouseDtos
{
    public class MovementDto
    {

        public string MovementID { get; set; }
        public string ProductPallet { get; set; }
        public string BatchPallet { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseAction { get; set; }
        public string ProductLocation { get; set; }
        public string PackageType { get; set; }
        public string Unit { get; set; }
        public string EmployeeID { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }

        public int Quantity { get; set; }
        public WarehouseDto Warehouse { get; set; }
        public ProductDto Product { get; set; }
        public LocationDto Location { get; set; }
        public ProductPackagesDto ProductPackage { get; set; }
        public BatchDto Batch { get; set; }
        public Employee Employee { get; set; }

        public IEnumerable<EmployeeTransaction> EmployeeTransactions { get; set; }
        public IEnumerable<ProductTransaction> ProductTransactions { get; set; }
        public IEnumerable<WarehouseTransaction> WarehouseTransactions { get; set; }

    }
}
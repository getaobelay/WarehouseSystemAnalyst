using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Data.Models.Dtos.UserModels;

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
        public EmployeeDto Employee { get; set; }
    }
}
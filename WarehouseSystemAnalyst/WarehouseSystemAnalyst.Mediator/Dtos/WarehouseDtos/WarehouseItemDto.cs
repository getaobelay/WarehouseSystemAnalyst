using System;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Mediator.Dtos.ContactDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Mediator.Helpers;

namespace WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos
{
    public class WarehouseItemDto : IBaseDto, IMapFrom<WarehouseItem>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ProductDto Product { get; set; }
        public AllocationWarehouseDto AllocationWarehouse { get; set; }
        public GoodsWarehouseDto GoodsWarehouse { get; set; }
        public ShippingWarehouseDto ShippingWarehouse { get; set; }
        public ProductPackageDto ProductPackage { get; set; }
        public AllocationDto Allocation { get; set; }
        public ProductMesureDto ProductMesures { get; set; }
        public LocationDto Location { get; set; }
        public BatchDto Batch { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
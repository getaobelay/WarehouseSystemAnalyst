﻿using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Mediator.Dtos.ContactDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos
{
    public class WarehouseItemDto : BaseDto, IMapFrom<WarehouseItem>
    {
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
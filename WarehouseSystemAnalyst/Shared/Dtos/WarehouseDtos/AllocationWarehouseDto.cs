using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;
using WarehouseSystemAnalyst.Shared.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Shared.Dtos.WarehouseDtos
{
    public class AllocationWarehouseDto : IBaseWarehouseDto, IMapFrom<AllocationWarehouse>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseItemID { get; set; }

        public IEnumerable<WarehouseItemDto> WarehouseItems { get; set; }
        public IEnumerable<LocationDto> Locations { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<BatchDto> Batches { get; set; }
    }
}
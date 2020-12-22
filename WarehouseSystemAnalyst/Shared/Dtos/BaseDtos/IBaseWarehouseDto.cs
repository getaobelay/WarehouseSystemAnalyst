using System.Collections.Generic;
using WarehouseSystemAnalyst.Shared.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Shared.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Shared.Dtos
{
    public interface IBaseWarehouseDto : IBaseDto
    {
        public string WarehouseName { get; set; }
        public string WarehouseItemID { get; set; }

        public IEnumerable<WarehouseItemDto> WarehouseItems { get; set; }
        public IEnumerable<LocationDto> Locations { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<BatchDto> Batches { get; set; }
    }
}
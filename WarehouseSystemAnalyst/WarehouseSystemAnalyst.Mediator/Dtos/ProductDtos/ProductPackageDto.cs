using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class ProductPackageDto : BaseDto, IMapFrom<ProductPackages>
    {
        public ProductDto Product { get; set; }
        public PackageDto Package { get; set; }
        public IEnumerable<WarehouseItemDto> WarehouseItems { get; set; }
        public IEnumerable<ProductItemDto> ProductItems { get; set; }
    }
}
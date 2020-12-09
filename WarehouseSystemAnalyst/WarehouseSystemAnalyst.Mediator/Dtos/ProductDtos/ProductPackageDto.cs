using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class ProductPackageDto : IBaseDto, IMapFrom<ProductPackages>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ProductDto Product { get; set; }
        public PackageDto Package { get; set; }
        public IEnumerable<WarehouseItemDto> WarehouseItems { get; set; }
        public IEnumerable<ProductItemDto> ProductItems { get; set; }
    }
}
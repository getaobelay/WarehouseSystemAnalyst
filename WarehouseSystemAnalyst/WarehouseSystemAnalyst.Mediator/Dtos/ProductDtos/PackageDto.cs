using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class PackageDto : BaseDto, IMapFrom<Package>
    {
        public string Type { get; set; }
        public virtual ICollection<ProductPackageDto> ProductPackages { get; set; }
    }
}
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.SupplyChainEntities
{
    public class ProductVendorDto : BaseDto, IMapFrom<ProductVendor>
    {
        public ProductDto Product { get; set; }
        public BatchDto Batch { get; set; }
        public VendorDto Vendor { get; set; }
    }
}
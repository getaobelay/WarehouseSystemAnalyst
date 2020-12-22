using System;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Shared.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Shared.Dtos.SupplyChainEntities
{
    public class ProductVendorDto : IBaseDto, IMapFrom<ProductVendor>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ProductDto Product { get; set; }
        public BatchDto Batch { get; set; }
        public VendorDto Vendor { get; set; }
    }
}
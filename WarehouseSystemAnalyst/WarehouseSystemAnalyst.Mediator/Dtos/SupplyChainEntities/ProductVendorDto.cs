using System;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Mediator.Helpers;

namespace WarehouseSystemAnalyst.Mediator.Dtos.SupplyChainEntities
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
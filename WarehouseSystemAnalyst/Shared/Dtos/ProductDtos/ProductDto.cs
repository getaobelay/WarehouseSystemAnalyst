using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Shared.Dtos.SupplyChainEntities;
using WarehouseSystemAnalyst.Shared.Dtos.WarehouseDtos;
using System;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Shared.Dtos.ProductDtos
{
    public class ProductDto : IBaseDto, IMapFrom<Product>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductName { get; set; }
        public Category Category { get; set; }
        public Stock Stock { get; set; }
        public Inventory Inventory { get; set; }
        public List<ProductItemDto> ProductItems { get; set; } = new List<ProductItemDto>();
        public List<WarehouseItemDto> WarehouseItems { get; set; } = new List<WarehouseItemDto>();
        public List<ProductMesureDto> Mesures { get; set; } = new List<ProductMesureDto>();
        public List<BatchDto> Batches { get; set; } = new List<BatchDto>();
        public List<ProductVendorDto> ProductVendors { get; set; } = new List<ProductVendorDto>();
        public List<ProductPackageDto> ProductPackages { get; set; } = new List<ProductPackageDto>();
    }
}
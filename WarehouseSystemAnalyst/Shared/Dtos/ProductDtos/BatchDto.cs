using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Shared.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Shared.Dtos.SupplyChainEntities;
using WarehouseSystemAnalyst.Shared.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Shared.Dtos.ProductDtos
{
    public class BatchDto : IBaseDto, IMapFrom<Batch>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public ProductDto Product { get; set; }
        public ProductItemDto ProductItem { get; set; }
        public InventoryDto Inventory { get; set; }
        public StockDto Stock { get; set; }
        public IEnumerable<ProductVendorDto> ProductSuppliers { get; set; }
        public IEnumerable<WarehouseItemDto> WarehouseItems { get; set; }
    }
}
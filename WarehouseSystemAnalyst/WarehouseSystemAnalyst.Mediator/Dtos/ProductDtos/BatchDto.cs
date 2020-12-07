using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.PalletDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.SupplyChainEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class BatchDto : BaseDto, IMapFrom<Batch>
    {
        public ProductDto Product { get; set; }
        public ProductItemDto ProductItem { get; set; }
        public InventoryDto Inventory { get; set; }
        public StockDto Stock { get; set; }
        public IEnumerable<ProductPalletDto> Pallets { get; set; }
        public IEnumerable<ProductVendorDto> ProductSuppliers { get; set; }
        public IEnumerable<WarehouseItemDto> WarehouseItems { get; set; }
    }
}
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Mediator.Dtos.PalletDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.SupplyChainEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class ProductDto : BaseDto, IMapFrom<Product>
    {
        public string ProductName { get; set; }
        public Category Category { get; set; }
        public Stock Stock { get; set; }
        public Inventory Inventory { get; set; }
        public IEnumerable<ProductItemDto> ProductItems { get; set; }
        public IEnumerable<WarehouseItemDto> WarehouseItems { get; set; }
        public IEnumerable<ProductPalletDto> Pallets { get; set; }
        public IEnumerable<ProductMesureDto> Mesures { get; set; }
        public IEnumerable<BatchDto> Batches { get; set; }
        public IEnumerable<ProductVendorDto> ProductVendors { get; set; }
        public IEnumerable<ProductPackageDto> ProductPackages { get; set; }
    }
}
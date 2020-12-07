using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.PalletDtos
{
    public class ProductPalletDto : BasePalletDto, IMapFrom<ProductPallet>
    {
        public ProductDto Product { get; set; }
        public BatchDto Batch { get; set; }
    }
}
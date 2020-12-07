using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class ProductMesureDto : BaseDto, IMapFrom<ProductMesures>
    {
        public decimal UnitBuyPrice { get; set; }
        public decimal UnitSellPrice { get; set; }
        public decimal QuantityPerUnit { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public ProductDto Product { get; set; }
        public MesureDto Mesure { get; set; }
    }
}
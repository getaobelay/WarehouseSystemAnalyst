using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class ProductItemDto : BaseDto, IMapFrom<ProductItem>
    {
        public string ProductName { get; set; }
        public decimal BuyPricePerUnit { get; set; }
        public decimal SellPricePerUnit { get; set; }
        public string Metrial { get; set; }

        public IEnumerable<BatchDto> Batches { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<MesureDto> UnitOfMesure { get; set; }
    }
}
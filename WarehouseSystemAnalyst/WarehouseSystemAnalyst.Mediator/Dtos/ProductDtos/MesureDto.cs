using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class MesureDto : BaseDto, IMapFrom<Mesure>
    {
        public IEnumerable<ProductMesureDto> ProductMesures { get; set; }
        public IEnumerable<ProductItemDto> ProductItems { get; set; }
    }
}
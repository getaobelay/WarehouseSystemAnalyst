using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.Helpers;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class MesureDto : IBaseDto, IMapFrom<Mesure>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IEnumerable<ProductMesureDto> ProductMesures { get; set; }
        public IEnumerable<ProductItemDto> ProductItems { get; set; }
    }
}
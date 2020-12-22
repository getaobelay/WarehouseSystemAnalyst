using System;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Shared.Dtos.ProductDtos
{
    public class ProductMesureDto : IBaseDto, IMapFrom<ProductMesures>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public decimal UnitBuyPrice { get; set; }
        public decimal UnitSellPrice { get; set; }
        public decimal QuantityPerUnit { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public ProductDto Product { get; set; }
        public MesureDto Mesure { get; set; }
    }
}
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using System;
using WarehouseSystemAnalyst.Mediator.Helpers;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class ProductItemDto : IBaseDto, IMapFrom<ProductItem>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ProductName { get; set; }
        public decimal BuyPricePerUnit { get; set; }
        public decimal SellPricePerUnit { get; set; }
        public string Metrial { get; set; }

        public IEnumerable<BatchDto> Batches { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<MesureDto> UnitOfMesure { get; set; }
    }
}
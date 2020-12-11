using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Server.BaseContollers
{
    public class ProductSingleResponse : IBaseResponse<ProductDto>
    {
        public ProductDto Object { get; set; }
        public decimal UnitsInStock { get; set; }
        public decimal UnitsInInventory { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> ErrorsMessages { get; set; }
    }
}
using System.Collections.Generic;
using WarehouseSystemAnalyst.Shared.Dtos;
using WarehouseSystemAnalyst.Shared.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Shared.Api.Responses
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
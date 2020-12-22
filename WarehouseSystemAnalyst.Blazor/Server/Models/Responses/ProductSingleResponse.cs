using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Server.BaseContollers;

namespace WarehouseSystemAnalyst.Blazor.Server.Models.Responses
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
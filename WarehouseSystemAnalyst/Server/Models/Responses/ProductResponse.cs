using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Server.BaseContollers
{
    public class ProductResponse : IBaseResponse<ProductDto>
    {
        public ProductResponse(object @object, decimal unitsInStock, decimal unitsInInventory, bool success, IEnumerable<string> errorsMessages)
        {
            Object = @object;
            UnitsInStock = unitsInStock;
            UnitsInInventory = unitsInInventory;
            Success = success;
            ErrorsMessages = errorsMessages;
        }

        public dynamic Object { get; set; }
        public decimal UnitsInStock { get; set; }
        public decimal UnitsInInventory { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> ErrorsMessages { get; set; }
    }
}
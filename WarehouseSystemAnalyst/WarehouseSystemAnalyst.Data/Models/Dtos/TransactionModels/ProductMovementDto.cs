using WarehouseSystemAnalyst.Data.Models.Dtos.WarehouseDtos;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.TransactionModels
{
    public class ProductMovementDto
    {
        public string ProductID { get; set; }
        public string MovementID { get; set; }

        public ProductDto Product { get; set; }
        public MovementDto Movement { get; set; }
    }
}

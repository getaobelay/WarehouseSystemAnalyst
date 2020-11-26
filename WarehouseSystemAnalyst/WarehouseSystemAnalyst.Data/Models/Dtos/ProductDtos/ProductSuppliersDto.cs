using WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos
{
    public class ProductSuppliersDto
    {

        public string ProductID { get; set; }

        public ProductDto Product { get; set; }
        public BatchDto Batch { get; set; }
        public SupplierDto Suppliers { get; set; }
    }
}
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos
{
    public class ProductDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string BatchPallet { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public int InventoryQuantity { get; set; }
        public int StockQuantity { get; set; }
        public string UnitOfMesure { get; set; }

        public CategoryDto Category { get; set; }
        public SubCategoryDto SubCategory { get; set; }
        public InventoryDto Inventory { get; set; }
        public StockDto Stock { get; set; }

        public IEnumerable<ProductMesuresDto> Mesures { get; set; }
        public IEnumerable<BatchDto> Batches { get; set; }
        public IEnumerable<ProductSuppliersDto> ProductSuppliers { get; set; }
        public IEnumerable<ProductPackagesDto> ProductPackages { get; set; }
    }
}
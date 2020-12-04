using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos
{
    public class BatchDto
    {
        public string BatchID { get; set; }
        public string BatchPallet { get; set; }
        public DateTime ExpriationDate { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int StockQuantity { get; set; }
        public int InventoryQuantity { get; set; }

        public ProductDto Product { get; set; }
        public StockDto Stock { get; set; }
        public InventoryDto Inventory { get; set; }
        public IEnumerable<ProductSuppliersDto> ProductSuppliers { get; set; }
    }
}
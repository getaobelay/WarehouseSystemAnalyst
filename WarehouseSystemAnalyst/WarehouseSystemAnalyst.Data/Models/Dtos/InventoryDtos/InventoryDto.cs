using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos
{
    public class InventoryDto
    {
        public string InventoryID { get; set; }
        public string ProductName { get; set; }
        public string BatchPallet { get; set; }
        public int TotalProductQuantity { get; set; }
        public int TotalProductBatchQuantity { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<BatchDto> Batches { get; set; }

        public int GetTotalWIthBatchQuantity(string batchID)
        {
            var quanitity = 0;
            if (Batches.Count() <= 0)
            {
                return quanitity;
            }
            if (Batches.Where(c => c.ProductID == batchID).Any())
            {
                foreach (var batch in Batches)
                {
                    quanitity += batch.Quantity;
                }
            }

            return quanitity;
        }

        public int GetTotalProductQuantity(string productID)
        {
            var quanitity = 0;
            if (Products.Count() <= 0)
            {
                return quanitity;
            }
            if (Products.Where(c => c.ProductID == productID).Any())
            {
                foreach (var product in Products)
                {
                    quanitity += product.Quantity;
                }
            }

            return quanitity;
        }
    }
}
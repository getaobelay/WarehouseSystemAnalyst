using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos
{
    public class SupplierDto
    {
        public int SupplierPK { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<ProductSuppliersDto> ProductSuppliers { get; set; }
    }
}
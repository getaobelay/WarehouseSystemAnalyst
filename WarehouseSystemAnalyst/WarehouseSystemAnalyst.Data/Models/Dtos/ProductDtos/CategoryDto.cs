using System.Collections.Generic;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos
{
    public class CategoryDto
    {
        public string CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
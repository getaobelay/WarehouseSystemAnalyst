using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class CategoryDto : BaseDto, IMapFrom<Category>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductID { get; set; }
        public string SubCategoryID { get; set; }

        public IEnumerable<SubCategoryDto> SubCategories { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class SubCategoryDto : BaseDto, IMapFrom<SubCategory>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryDto Category { get; set; }
    }
}
using System;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Shared.Dtos.ProductDtos
{
    public class SubCategoryDto : IBaseDto, IMapFrom<SubCategory>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryDto Category { get; set; }
    }
}
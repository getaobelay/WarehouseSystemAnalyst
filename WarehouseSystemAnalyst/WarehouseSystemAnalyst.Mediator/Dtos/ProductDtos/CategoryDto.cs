using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class CategoryDto : IBaseDto, IMapFrom<Category>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductID { get; set; }
        public string SubCategoryID { get; set; }

        public IEnumerable<SubCategoryDto> SubCategories { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
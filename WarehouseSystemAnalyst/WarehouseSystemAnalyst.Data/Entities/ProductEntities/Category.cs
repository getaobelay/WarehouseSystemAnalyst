using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities
{
    public class Category : BaseProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductID { get; set; }
        public string SubCategoryID { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; } = new HashSet<SubCategory>();
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
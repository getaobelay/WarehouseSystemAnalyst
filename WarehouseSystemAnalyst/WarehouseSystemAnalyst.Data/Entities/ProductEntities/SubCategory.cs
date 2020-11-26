using WarehouseSystemAnalyst.Data.Entites.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
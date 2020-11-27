using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entites.ProductEntities;

namespace WarehouseSystemAnalyst.Data.Interfaces.Models
{
    public interface IBaseItem : IBaseEntity
    {
        public string ProductID { get; set; }
        public string BatchID { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Batch> Batches { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entites.ProductEntities;
using WarehouseSystemAnalyst.Data.Models.Data.ProductModels;

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

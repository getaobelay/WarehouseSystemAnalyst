using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{
    public class Category : BaseProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductID { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
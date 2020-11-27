using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entites.ProductEntities
{
    public class Mesure : BaseProduct
    {
        public string Measurement { get; set; }
        public ICollection<ProductMesures> ProductMesures { get; set; } = new HashSet<ProductMesures>();

    }
}
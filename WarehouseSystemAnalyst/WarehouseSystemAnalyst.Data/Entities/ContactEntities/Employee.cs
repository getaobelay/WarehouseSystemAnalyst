using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;

namespace WarehouseSystemAnalyst.Data.Entities.ContactEntities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ItemId { get; set; }

        public virtual ICollection<ProductItem> Items { get; set; }
    }
}
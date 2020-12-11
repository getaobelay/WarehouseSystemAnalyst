using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;

namespace WarehouseSystemAnalyst.Data.Entities.ContactEntities
{
    public class Employee : IBaseEntity
    {
        public int Id { get; set; }
        public string? PK { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WarehouseItemId { get; set; }

        public virtual ICollection<WarehouseItem> WarehouseItems => new HashSet<WarehouseItem>();
    }
}
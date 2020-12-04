using System;

namespace WarehouseSystemAnalyst.Data.Interfaces.Models
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        string PK { get; set; }

        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }

        DateTime CreateDate { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
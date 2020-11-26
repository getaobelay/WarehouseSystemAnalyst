using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

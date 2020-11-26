using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Services.Models.BaseEntity
{
    public abstract class BaseMission : IBaseMission
    {
        public abstract int Id { get; set; }
        public abstract string PK { get; set; }
        public abstract DateTime CreateDate { get; set; }
        public abstract DateTime ModifiedDate { get; set; }
        public abstract string CreatedBy { get; set; }
        public abstract string ModifiedBy { get; set; }
    }
}

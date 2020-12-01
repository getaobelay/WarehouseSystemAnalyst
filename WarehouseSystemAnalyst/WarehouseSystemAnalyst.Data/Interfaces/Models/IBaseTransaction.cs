using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystemAnalyst.Data.Interfaces.Models
{
    public interface IBaseTransaction : IBaseEntity
    {
        public string Note { get; set; }
    }
}

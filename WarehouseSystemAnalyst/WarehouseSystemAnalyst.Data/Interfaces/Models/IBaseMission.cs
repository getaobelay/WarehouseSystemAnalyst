using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystemAnalyst.Data.Interfaces.Models
{
    public interface IBaseMission<Item> : IBaseEntity
    {
        public string AssignedTo { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}

﻿using System.Collections.Generic;

namespace WarehouseSystemAnalyst.Data.Entities.BaseEntites
{
    public interface IBaseMission<Item> : IBaseEntity
    {
        public string AssignedTo { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
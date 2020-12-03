﻿using System;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Entities.BaseEntites
{
    public abstract class BaseMission<TEntity> : IBaseMission<TEntity>
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string AssignedTo { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<TEntity> Items { get; set; }
    }
}
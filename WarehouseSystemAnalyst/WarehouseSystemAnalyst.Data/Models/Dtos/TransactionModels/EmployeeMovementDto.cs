﻿using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.TransactionModels
{
    public class EmployeeMovementDto
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string ProductID { get; set; }
        public string ProductPallet { get; set; }
        public string ActionType { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public string ItemID { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual WarehouseItem Item { get; set; }
    }
}

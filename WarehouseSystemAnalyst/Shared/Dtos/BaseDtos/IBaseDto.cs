using System;

namespace WarehouseSystemAnalyst.Shared.Dtos.BaseDtos
{

    public interface IBaseDto
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
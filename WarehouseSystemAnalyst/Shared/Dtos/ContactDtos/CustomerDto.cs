using System;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Shared.Dtos.ContactDtos
{
    //customer
    public class CustomerDto : IBaseDto, IMapFrom<Customer>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
using AutoMapper;
using WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites;
using WarehouseSystemAnalyst.Data.Models.Dtos.TransactionModels;

namespace WarehouseSystemAnalyst.Configurations.MappingProfiles.TransactionConfigs
{
    public class EmployeeMovementProfile : Profile
    {
        public EmployeeMovementProfile()
        {
            CreateMap<EmployeeMovementDto, EmployeeTransaction>();
            CreateMap<EmployeeTransaction, EmployeeMovementDto>();
        }
    }
}
using AutoMapper;
using WarehouseSystemAnalyst.Data.Models.Data.TransactionModels;
using WarehouseSystemAnalyst.Data.Models.Dtos.TransactionModels;

namespace WarehouseSystemAnalyst.Configurations.MappingProfiles.TransactionConfigs
{
    public class WarehouseMovementProfile : Profile
    {
        public WarehouseMovementProfile()
        {
            CreateMap<WarehouseMovementDto, WarehouseTransaction>();
            CreateMap<WarehouseTransaction, WarehouseMovementDto>();
        }
    }
}
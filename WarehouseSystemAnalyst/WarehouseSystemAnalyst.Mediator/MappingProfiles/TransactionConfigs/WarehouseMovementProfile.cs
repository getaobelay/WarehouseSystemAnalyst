using AutoMapper;
using WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites;
using WarehouseSystemAnalyst.Data.Models.Dtos.TransactionModels;

namespace WarehouseSystemAnalyst.Mediator.MappingProfiles.TransactionConfigs
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
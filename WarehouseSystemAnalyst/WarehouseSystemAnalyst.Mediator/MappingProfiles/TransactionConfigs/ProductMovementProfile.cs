using AutoMapper;
using WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites;
using WarehouseSystemAnalyst.Data.Models.Dtos.TransactionModels;

namespace WarehouseSystemAnalyst.Mediator.MappingProfiles.TransactionConfigs
{
    public class ProductMovementProfile : Profile
    {
        public ProductMovementProfile()
        {
            CreateMap<ProductMovementDto, ProductTransaction>();
            CreateMap<ProductTransaction, ProductMovementDto>();
        }
    }
}
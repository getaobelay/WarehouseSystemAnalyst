using AutoMapper;
using WarehouseSystemAnalyst.Data.Models.Data.TransactionModels;
using WarehouseSystemAnalyst.Data.Models.Dtos.TransactionModels;

namespace WarehouseSystemAnalyst.Configurations.MappingProfiles.TransactionConfigs
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
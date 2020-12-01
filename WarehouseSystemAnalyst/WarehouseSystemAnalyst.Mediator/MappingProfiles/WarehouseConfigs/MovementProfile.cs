using AutoMapper;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Models.Dtos.WarehouseDtos;

namespace WarehouseSystemAnalyst.Mediator.MappingProfiles.WarehouseConfigs
{
    /*
    public class MovementProfile : Profile
    {
        public MovementProfile()
        {
            CreateMap<MovementDto, Movement>();

            CreateMap<Movement, MovementDto>()
                  .ForMember(dest => dest.ProductPallet, opt => opt.MapFrom(src => src.Product.PalletID))
                  .ForMember(dest => dest.BatchPallet, opt => opt.MapFrom(src => src.Batch.Id))
                  .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Warehouse.WarehouseName))
                  .ForMember(dest => dest.PackageType, opt => opt.MapFrom(src => src.ProductPackage.Package.Type))
                  .ForMember(dest => dest.ProductLocation, opt => opt.MapFrom(src =>
                                                                    src.Location.LocationRow + "-" +
                                                                    src.Location.LocationColum + "-" +
                                                                    src.Location.LocationShelf));
        }
    }
    */
}
﻿using AutoMapper;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Models.Dtos.WarehouseDtos;

namespace WarehouseSystemAnalyst.Configurations.MappingProfiles.WarehouseConfigs
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationDto, Location>();
            CreateMap<Location, LocationDto>()
                        .ForMember(dest => dest.Location, opt => opt.MapFrom(src =>
                                                                  src.LocationRow + "-" +
                                                                  src.LocationColum + "-" +
                                                                  src.LocationShelf));
        }
    }
}
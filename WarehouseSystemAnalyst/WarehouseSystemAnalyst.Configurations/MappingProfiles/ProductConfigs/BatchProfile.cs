﻿using AutoMapper;
using WarehouseSystemAnalyst.Data.Entites.ProductEntities;
using WarehouseSystemAnalyst.Data.Models.Data.ProductModels;
using WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Configurations.MappingProfiles.ProductConfigs
{
    public class BatchProfile : Profile
    {
        public BatchProfile()
        {
            CreateMap<Batch, BatchDto>().ReverseMap();
            CreateMap<Batch, BatchDto>()
                       .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                       .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.Stock.Quantity))
                       .ForMember(dest => dest.InventoryQuantity, opt => opt.MapFrom(src => src.Inventory.Quantity));
        }
    }
}
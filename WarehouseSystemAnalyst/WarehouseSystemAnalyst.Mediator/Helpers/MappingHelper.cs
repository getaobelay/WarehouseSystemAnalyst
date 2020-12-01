using AutoMapper;
using System;
using WarehouseSystemAnalyst.Mediator.MappingProfiles.InventoryConfigs;
using WarehouseSystemAnalyst.Mediator.MappingProfiles.ProductConfigs;
using WarehouseSystemAnalyst.Mediator.MappingProfiles.WarehouseConfigs;

namespace WarehouseSystemAnalyst.Mediator.Helpers
{
    /// <summary>
    /// Return a mapper with all the profile configurations
    /// </summary>
    ///
    public static class MappingHelper
    {
        /// <summary>
        /// var destination = Mapping.Mapper.Map<Destination>(yourSourceInstance);
        /// </summary>
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

                cfg.AddProfile(typeof(InventoryProfile));
                cfg.AddProfile(typeof(StockProfile));

                cfg.AddProfile(typeof(BatchProfile));
                cfg.AddProfile(typeof(ProductMesureProfile));
                cfg.AddProfile(typeof(ProductPackageProfile));
                cfg.AddProfile(typeof(ProductProfile));
                cfg.AddProfile(typeof(RelatedProductProfiles));

                cfg.AddProfile(typeof(LocationProfile));
                ///cfg.AddProfile(typeof(MovementProfile));
                cfg.AddProfile(typeof(WarehouseProfile));
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
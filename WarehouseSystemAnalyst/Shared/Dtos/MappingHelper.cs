using AutoMapper;
using System;

namespace WarehouseSystemAnalyst.Shared.Dtos
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

                cfg.AddProfile(typeof(MappingProfile));
            });

            return config.CreateMapper();
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
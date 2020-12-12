using Autofac;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.loC
{
    public static class RegisterGenericProccessorsHelepr
    {
        public static ContainerBuilder RegisterAllProccessors<TEntity, TDto>(this ContainerBuilder builder)
 where TEntity : class, IBaseEntity, new()
 where TDto : class, IBaseDto, new()
        {
            builder.RegisterValidators<TEntity, TDto>();
            builder.RegisterValidationProccessors<TEntity, TDto>();
            builder.RegisterPreCommandProccessors<TEntity, TDto>();
            builder.RegisterCommandProccessors<TEntity, TDto>();

            return builder;
        }

    }
}

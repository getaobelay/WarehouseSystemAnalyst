using Autofac;
using FluentValidation;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Validation;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Mediator.loC
{
    public static class RegisterGenericValidatorsHelper
    {
        public static ContainerBuilder RegisterValidators<TEntity, TDto>(this ContainerBuilder builder)
    where TEntity : class, IBaseEntity, new()
    where TDto : class, IBaseDto, new()

        {
            builder.RegisterGeneric(typeof(CreateCommandValidator<,>)).As(typeof(IValidator<>));
            builder.RegisterGeneric(typeof(UpdateCommandValidator<,>)).As(typeof(IValidator<>));
            builder.RegisterGeneric(typeof(DeleteCommandValidator<,>)).As(typeof(IValidator<>));

            return builder;
        }

    }
}

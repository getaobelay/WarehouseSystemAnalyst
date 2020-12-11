using Autofac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests;
using WarehouseSystemAnalyst.Mediator.Commands.Validation.CommonValidation;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.loC
{
    public static class RegisterGenericValidators
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

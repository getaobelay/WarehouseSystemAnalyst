using Autofac;
using MediatR;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Commands.Behaviours.CommonBehaviours;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests;
using WarehouseSystemAnalyst.Mediator.Commands.Responses.CommonResponses;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.loC
{
    public static class RegisterValidationBehavioursHelper
    {
        public static ContainerBuilder RegisterValidationBehaviours<TEntity, TDto>(this ContainerBuilder builder)
     where TEntity : class, IBaseEntity, new()
     where TDto : class, IBaseDto, new()
        {
            builder.RegisterType<ValidationBehaviour<CreateCommandRequest<TEntity, TDto>, CommandResponse<TDto>, TEntity, TDto>>()
                                           .As<IPipelineBehavior<CreateCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();

            builder.RegisterType<ValidationBehaviour<DeleteCommandRequest<TEntity, TDto>, CommandResponse<TDto>, TEntity, TDto>>()
                                       .As<IPipelineBehavior<DeleteCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();

            builder.RegisterType<ValidationBehaviour<UpdateCommandRequest<TEntity, TDto>, CommandResponse<TDto>, TEntity, TDto>>()
                                       .As<IPipelineBehavior<UpdateCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();
            return builder;
        }

    }
}

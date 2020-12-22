using Autofac;
using MediatR;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Responses;
using WarehouseSystemAnalyst.Mediator.Proccessors;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Mediator.loC
{
    public static class RegisterValidationProccessorsHelper
    {
        public static ContainerBuilder RegisterValidationProccessors<TEntity, TDto>(this ContainerBuilder builder)
     where TEntity : class, IBaseEntity, new()
     where TDto : class, IBaseDto, new()
        {
            builder.RegisterType<CommandValidationProccessor<CreateCommandRequest<TEntity, TDto>, CommandResponse<TDto>, TEntity, TDto>>()
                                           .As<IPipelineBehavior<CreateCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();

            builder.RegisterType<CommandValidationProccessor<DeleteCommandRequest<TEntity, TDto>, CommandResponse<TDto>, TEntity, TDto>>()
                                       .As<IPipelineBehavior<DeleteCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();

            builder.RegisterType<CommandValidationProccessor<UpdateCommandRequest<TEntity, TDto>, CommandResponse<TDto>, TEntity, TDto>>()
                                       .As<IPipelineBehavior<UpdateCommandRequest<TEntity, TDto>, CommandResponse<TDto>>>();
            return builder;
        }

    }
}

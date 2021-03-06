﻿using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Implementation;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Responses;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;
using WarehouseSystemAnalyst.Shared.Dtos;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Handlers
{
    /// <summary>
    /// Generic mediator handler creates a new record in the database
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TRequest">Type of ICommandWrapper command</typeparam>
    public class CreateCommandHandler<TEntity, TDto, TRequest> : IRequestHandler<TRequest, CommandResponse<TDto>>
    where TEntity : class, IBaseEntity, new()
    where TDto : class, IBaseDto, new()
    where TRequest : CreateCommandRequest<TEntity, TDto>, new()
    {
        private DataRepository<TEntity> repository;

        public CreateCommandHandler(IDataContext context)
        {
            repository = new DataRepository<TEntity>(context.UnitOfWork);
        }


        public async Task<CommandResponse<TDto>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedInsertObject = MappingHelper.Mapper.Map<TEntity>(request.CreateObject);


                var result = await repository.InsertAsync(mappedInsertObject);
                if (result != null)
                {
                    await repository.UnitOfWork.SaveChangesAsync();
                    var mapped = MappingHelper.Mapper.Map<TDto>(result);
                    return await Task.FromResult(CommandResponse.CommandExecuted(message: "Recored Created", mapped));
                }

                return await Task.FromResult(CommandResponse.CommandFailed<TDto>(message: "Failed to insert record into the database"));

            }
            catch (Exception)
            {
                throw;

            }
        }
    }
}
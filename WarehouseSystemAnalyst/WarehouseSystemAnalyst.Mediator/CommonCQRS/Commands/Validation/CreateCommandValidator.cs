using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Implementation;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Validation
{

    public class CreateCommandValidator<TEntity, TDto> : AbstractValidator<CreateCommandRequest<TEntity, TDto>>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        private DataRepository<TEntity> repository;

        public CreateCommandValidator(IDataContext context)
        {
            repository = new DataRepository<TEntity>(context.UnitOfWork);
        }
        public CreateCommandValidator()
        {
            RuleFor(x => x.CreateObject)
                .NotNull()
                .WithMessage("Entity should not be null");

            RuleFor(x => x.CreateObject.PK)
              .NotEmpty()
              .WithMessage("Id should not be null");

        }


    }
}

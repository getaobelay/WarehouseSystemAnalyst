using FluentValidation;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Validation
{
    public class DeleteCommandValidator<TEntity, TDto> : AbstractValidator<UpdateCommandRequest<TEntity, TDto>>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        public DeleteCommandValidator()
        {

            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage("Id should not be null");

        }
    }
}

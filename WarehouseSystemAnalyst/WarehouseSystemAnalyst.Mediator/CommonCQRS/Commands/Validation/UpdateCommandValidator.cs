using FluentValidation;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Validation
{

    public class UpdateCommandValidator<TEntity, TDto> : AbstractValidator<UpdateCommandRequest<TEntity, TDto>>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        public UpdateCommandValidator()
        {
            RuleFor(x => x.UpdatedObject)
                .NotEmpty()
                .WithMessage("Entity should not be null");

            RuleFor(x => x.UpdatedObject.PK)
                .NotEmpty()
                .WithMessage("Id should not be null");

            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage("Id should not be null");
        }
    }
}

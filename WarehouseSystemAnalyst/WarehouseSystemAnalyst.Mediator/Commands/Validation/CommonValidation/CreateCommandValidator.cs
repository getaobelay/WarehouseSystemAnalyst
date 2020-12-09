using FluentValidation;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Validation.CommonValidation
{

    public class CreateCommandValidator<TEntity, TDto> : AbstractValidator<CreateCommandRequest<TEntity, TDto>>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Entity)
                .NotEmpty()
                .WithMessage("Entity should not be null");
        }
    }
}

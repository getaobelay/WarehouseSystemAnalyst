using FluentValidation;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Queries.Requests;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Queries.Validation
{
    /// <summary>
    /// validater
    /// </summary>
    public class SingleQueryValidator<TEntity, TDto> : AbstractValidator<SingleQueryRequest<TEntity, TDto>>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        public SingleQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id should not be null");
        }
    }



}

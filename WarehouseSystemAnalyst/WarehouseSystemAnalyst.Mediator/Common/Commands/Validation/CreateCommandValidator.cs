using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Common.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Mediator.Common.Commands.Validation
{
    /// <summary>
    /// validater
    /// </summary>
    public class CreateCommandValidator<TEntity, TDto> : AbstractValidator<CreateCommand<TEntity, TDto>>
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

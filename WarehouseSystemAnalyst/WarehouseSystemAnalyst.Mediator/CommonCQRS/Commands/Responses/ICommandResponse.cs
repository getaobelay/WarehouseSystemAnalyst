using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Responses
{
    public interface ICommandResponse<TDto>
        where TDto : class, IBaseDto, new()
    {
        public bool Error { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}

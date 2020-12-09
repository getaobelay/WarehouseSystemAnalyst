using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Responses
{

    public class ListQueryResponse<TDto>
        where TDto : class, IBaseDto, new()
    {
        public IEnumerable<TDto> Dtos { get; set; }
        public bool Error { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
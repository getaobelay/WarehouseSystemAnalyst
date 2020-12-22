using System.Collections.Generic;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Queries.Responses
{

    public class ListQueryResponse<TDto>
        where TDto : class, IBaseDto, new()
    {
        public IEnumerable<TDto> Dtos { get; set; }
        public bool Error { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
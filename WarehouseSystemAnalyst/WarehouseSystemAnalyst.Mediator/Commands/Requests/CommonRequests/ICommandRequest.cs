using MediatR;
using MediatR;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.Enrollment;
using WarehouseSystemAnalyst.Mediator.Commands.Responses.CommonResponses;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests
{
    public interface ICommandRequest<TEntity, TDto> : IRequest<CommandResponse<TDto>>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        List<Audit> Audits { get; set; }
        List<AuditEntry> AuditEntries { get; set; }
    }
}

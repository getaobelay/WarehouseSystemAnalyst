using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystemAnalyst.Interfaces.Repository
{
    public interface IMissionRepository<TSource>
        where TSource : class, new()
    {
        Task<bool> ChangeStatus(object missionId, int quantity);
        Task<bool> ChangeStatus(object missionId);
        Task<bool> MoveMission(object missionId, int quantity);
        Task<bool> CompleteMission(object missionId, int quantity);
    }
}

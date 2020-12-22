using AutoMapper;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;

namespace WarehouseSystemAnalyst.Shared.Dtos
{
    public interface IMapFrom<TEntity>
        where TEntity : class, IBaseEntity, new()
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(TEntity), GetType()).ReverseMap();
    }
}
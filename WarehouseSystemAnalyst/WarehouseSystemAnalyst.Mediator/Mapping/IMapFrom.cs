using AutoMapper;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;

namespace WarehouseSystemAnalyst.Mediator.Mapping
{
    public interface IMapFrom<TEntity>
        where TEntity : class, IBaseEntity, new()
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(TEntity), GetType()).ReverseMap();
    }
}
namespace WarehouseSystemAnalyst.Data.Interfaces.Models
{
    public interface IBaseTransaction : IBaseEntity
    {
        public string Note { get; set; }
    }
}
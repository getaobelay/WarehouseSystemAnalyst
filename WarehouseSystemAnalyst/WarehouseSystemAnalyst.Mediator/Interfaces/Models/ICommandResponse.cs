namespace WarehouseSystemAnalyst.Mediator.Interfaces.Models
{
    public interface ICommandResponse<TModel>
        where TModel : class, new()
    {
        public TModel Model { get; set; }
        public bool Error { get; set; }
        string Message { get; set; }
    }
}

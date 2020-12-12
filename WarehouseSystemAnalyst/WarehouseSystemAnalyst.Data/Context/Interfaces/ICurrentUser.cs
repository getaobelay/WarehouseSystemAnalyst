namespace WarehouseSystemAnalyst.Data.DataContext
{
    public interface ICurrentUser
    {
        string GetUsername();
        bool IsAuthenticated();
    }
}
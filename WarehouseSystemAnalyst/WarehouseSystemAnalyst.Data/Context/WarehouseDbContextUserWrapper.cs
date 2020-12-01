namespace WarehouseSystemAnalyst.Data.DataContext
{
    public class WarehouseDbContextUserWrapper
    {
        public WarehouseDbContext Context;

        public WarehouseDbContextUserWrapper(WarehouseDbContext context, ICurrentUser currentUser)
        {
            context.CurrentUser = currentUser;
            this.Context = context;
        }
    }
}
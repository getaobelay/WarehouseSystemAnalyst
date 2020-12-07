namespace WarehouseSystemAnalyst.Data.DataContext
{
    public class WarehouseDbContextWrapper
    {
        public WarehouseDbContext Context;

        public WarehouseDbContextWrapper(WarehouseDbContext context, ICurrentUser currentUser)
        {
            context.CurrentUser = currentUser;
            this.Context = context;
        }
    }
}
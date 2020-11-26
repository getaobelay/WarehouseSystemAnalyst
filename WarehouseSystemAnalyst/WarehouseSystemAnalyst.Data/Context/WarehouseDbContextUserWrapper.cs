using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystemAnalyst.Data.Context
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

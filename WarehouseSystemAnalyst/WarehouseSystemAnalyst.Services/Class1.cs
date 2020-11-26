using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Services
{


    public interface ICurrentUser
    {
        string GetUsername();
    }

    public class ApplicationDbContextUserWrapper
    {
        public ApplicationDbContext Context;

        public ApplicationDbContextUserWrapper(ApplicationDbContext context, ICurrentUser currentUser)
        {
            context.CurrentUser = currentUser;
            this.Context = context;
        }
    }

    public class ApplicationDbContext : DbContext
    {

        public ICurrentUser CurrentUser;

        public override int SaveChanges()
        {
            var now = DateTime.Now;

            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is IBaseEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreateDate = now;
                            entity.ModifiedDate = now;
                            entity.CreatedBy = CurrentUser.GetUsername();
                            entity.ModifiedBy = CurrentUser.GetUsername();
                            break;
                        case EntityState.Modified:
                            Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                            Entry(entity).Property(x => x.CreateDate).IsModified = false;
                            entity.ModifiedDate = now;
                            entity.ModifiedBy = CurrentUser.GetUsername();
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

    }
}

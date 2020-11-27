using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;
using System;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Entites.ProductEntities;
using WarehouseSystemAnalyst.Data.Entites.InventoryEntites;
using System.Linq;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Context
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext()
        {
        }

        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
            : base(options)
        {

        }

        //#region Transactions Related DbSets
        //public virtual DbSet<EmployeeTransaction> EmployeeTransactions { get; set; }
        //public virtual DbSet<ProductTransaction> ProductTransactions { get; set; }
        //public virtual DbSet<WarehouseTransaction> WarehouseTransactions { get; set; }
        //#endregion Transactions Related DbSets

        //#region Product Related DbSts

        //public virtual DbSet<Batch> Batches { get; set; }
        //public virtual DbSet<Package> Packages { get; set; }
        //public virtual DbSet<ProductPallet> Pallet { get; set; }
        //public virtual DbSet<Product> Products { get; set; }
        //public virtual DbSet<Category> Categories { get; set; }
        //public virtual DbSet<SubCategory> SubCategories { get; set; }
        //public virtual DbSet<ProductSuppliers> ProductSuppliers { get; set; }
        //public virtual DbSet<ProductMesures> ProductMesures { get; set; }
        //public virtual DbSet<ProductPackages> ProductPackages { get; set; }
        //public virtual DbSet<Mesure> UnitOfMesures { get; set; }


        //#endregion Product Related DbSts

        //#region Warehouse Related DbSts
        //public virtual DbSet<Movement> Movements { get; set; }
        //public virtual DbSet<Location> Locations { get; set; }
        //public virtual DbSet<Warehouse> Warehouses { get; set; }

        //#endregion Warehouse Related DbSts

        //#region Inventory Related DbSts
        //public virtual DbSet<Inventory> Inventories { get; set; }
        //public virtual DbSet<Stock> Stocks { get; set; }
        //public virtual DbSet<Supplier> Suppliers { get; set; }

        //#endregion Inventory Related DbSts

        public DbSet<Audit> Audits { get; set; }


        ///public virtual DbSet<BaseTransaction> ContractTransaction { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WarehouseProjectDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entityTypes = Assembly.GetExecutingAssembly()
           .GetTypes()
           .Where(x => !string.IsNullOrEmpty(x.Namespace)
               && x.BaseType != null
               && x.BaseType == typeof(BaseEntity))
           .ToList();

            var method = typeof(ModelBuilder).GetMethod("Entity");

            foreach (var type in entityTypes)
            {
                method.MakeGenericMethod(type)
                      .Invoke(modelBuilder, new object[] { });
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        public ICurrentUser CurrentUser;

        private void BaseEntitySaving()
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
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            BaseEntitySaving();
            var auditEntries = OnBeforeSaveChanges();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await OnAfterSaveChanges(auditEntries);
            return result;
        }

        private List<AuditEntry> OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Metadata.GetTableName(); // EF Core 3.1: entry.Metadata.GetTableName();
                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    // The following condition is ok with EF Core 2.2 onwards.
                    // If you are using EF Core 2.1, you may need to change the following condition to support navigation properties: https://github.com/dotnet/efcore/issues/17700
                    // if (property.IsTemporary || (entry.State == EntityState.Added && property.Metadata.IsForeignKey()))
                    if (property.IsTemporary)
                    {
                        // value will be generated by the database, get the value after saving
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }

            // Save audit entities that have all the modifications
            foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                Audits.Add(auditEntry.ToAudit());
            }

            // keep a list of entries where the value of some properties are unknown at this step
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }

        private Task OnAfterSaveChanges(List<AuditEntry> auditEntries)
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return Task.CompletedTask;

            foreach (var auditEntry in auditEntries)
            {
                BaseEntitySaving();

                // Get the final value of the temporary properties
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }

                // Save the Audit entry
                Audits.Add(auditEntry.ToAudit());
            }

            return SaveChangesAsync();
        }

    }

}


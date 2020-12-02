﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.ContactEntities;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Entities.Enrollment;
using WarehouseSystemAnalyst.Data.Entities.MissionEntites;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;

namespace WarehouseSystemAnalyst.Data.DataContext
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

        //public DbSet<Customer> Customers { get; set; }

        public DbSet<BaseStock> BaseStocks { get; set; }
        public DbSet<BaseWarehouse> Warehouses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CollectItem> CollectItems { get; set; }
        public DbSet<CollectProductItem> CollectProductItems { get; set; }
        public DbSet<CollectProducts> CollectProducts { get; set; }
        public DbSet<ProductPallet> ProductPallets { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Mesure> Mesures { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ProductMesures> ProductMesures { get; set; }
        public DbSet<ProductPackages> ProductPackages { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ProductVendor> ProductVendors { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Allocation> Allocations { get; set; }
        public DbSet<AllocationWarehouse> AllocationWarehouses { get; set; }
        public DbSet<GoodsWarehouse> GoodsWarehouses { get; set; }
        public DbSet<ShippingWarehouse> ShippingWarehouses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
        public DbSet<Audit> Audits { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QHFHS9D;Initial Catalog=WarehouseDb;Integrated Security=True;MultipleActiveResultSets=true");

                //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WarehouseProjectDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
﻿using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;

namespace WarehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface IUnitOfWorkRepository<out TContext>
        where TContext : DbContext, new()
    {
        TContext Context { get; }

        Task CreateTransactionAsync();

        Task CommitAsync();

        Task RollbackAsync();

        Task SaveChangesAsync();

        void Dispose();
    }
}
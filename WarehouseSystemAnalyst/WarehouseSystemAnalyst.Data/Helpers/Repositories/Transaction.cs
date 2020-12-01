using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Data.Helpers.Repositories
{
    public static class Transaction
    {
        public static Transaction<TSourceEntity, TDestinationEntity>
            DestinationEmpty<TSourceEntity, TDestinationEntity>(TSourceEntity source)
                where TDestinationEntity : class, IBaseEntity, new()
                where TSourceEntity : class, IBaseEntity, new()
            => new Transaction<TSourceEntity, TDestinationEntity>(source: source, destination: default);


        public static Transaction<TSourceEntity, TDestinationEntity>
            Ok<TSourceEntity, TDestinationEntity>(TSourceEntity source, TDestinationEntity destination)
                where TDestinationEntity : class, IBaseEntity, new()
                where TSourceEntity : class, IBaseEntity, new()
            => new Transaction<TSourceEntity, TDestinationEntity>(source: source,destination: destination);


        public static Transaction<TSourceEntity, TDestinationEntity>
            Empty<TSourceEntity, TDestinationEntity>()
                where TDestinationEntity : class, IBaseEntity, new()
                where TSourceEntity : class, IBaseEntity, new() =>
            new Transaction<TSourceEntity, TDestinationEntity>(source: default, destination: default);

        public static ListTransaction<TSourceEntity, TDestinationEntity>
          ListDestinationEmpty<TSourceEntity, TDestinationEntity>(IEnumerable<TSourceEntity> source)
              where TDestinationEntity : class, IBaseEntity, new()
              where TSourceEntity : class, IBaseEntity, new()
          => new ListTransaction<TSourceEntity, TDestinationEntity>(source: source, destination: default);


        public static ListTransaction<TSourceEntity, TDestinationEntity>
            ListOk<TSourceEntity, TDestinationEntity>(IEnumerable<TSourceEntity> source, IEnumerable<TDestinationEntity> destination)
                where TDestinationEntity : class, IBaseEntity, new()
                where TSourceEntity : class, IBaseEntity, new()
            => new ListTransaction<TSourceEntity, TDestinationEntity>(source: source, destination: destination);


        public static ListTransaction<TSourceEntity, TDestinationEntity>
            ListEmpty<TSourceEntity, TDestinationEntity>()
                where TDestinationEntity : class, IBaseEntity, new()
                where TSourceEntity : class, IBaseEntity, new() =>
            new ListTransaction<TSourceEntity, TDestinationEntity>(source: default, destination: default);

    }

    public class Transaction<TSourceEntity, TDestinationEntity>
        where TSourceEntity : class, IBaseEntity, new()
        where TDestinationEntity : class, IBaseEntity, new()
    {
        public Transaction(TSourceEntity source, TDestinationEntity destination)
        {
            this.source = source;
            this.destination = destination;
        }

        public TSourceEntity source { get; set; }
        public TDestinationEntity destination { get; set; }

    }


    public class ListTransaction<TSourceEntity, TDestinationEntity>
       where TSourceEntity : class, IBaseEntity, new()
       where TDestinationEntity : class, IBaseEntity, new()
    {
        public ListTransaction(IEnumerable<TSourceEntity> source, IEnumerable<TDestinationEntity> destination)
        {
            this.source = source;
            this.destination = destination;
        }

        public IEnumerable<TSourceEntity> source { get; set; }
        public IEnumerable<TDestinationEntity> destination { get; set; }

    }
}
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Helpers.Repositories
{
    public static class ListTransaction
    {
        public static ListTransaction<TSourceEntity, TDestinationEntity>
        DestinationEmpty<TSourceEntity, TDestinationEntity>(IEnumerable<TSourceEntity> source)
            where TDestinationEntity : class, IBaseEntity, new()
            where TSourceEntity : class, IBaseEntity, new()
        => new ListTransaction<TSourceEntity, TDestinationEntity>(source: source, destination: default);

        public static ListTransaction<TSourceEntity, TDestinationEntity>
        SourceEmpty<TSourceEntity, TDestinationEntity>(IEnumerable<TDestinationEntity> destination)
            where TDestinationEntity : class, IBaseEntity, new()
            where TSourceEntity : class, IBaseEntity, new()
        => new ListTransaction<TSourceEntity, TDestinationEntity>(destination: destination, source: default);

        public static ListTransaction<TSourceEntity, TDestinationEntity>
            ListsFound<TSourceEntity, TDestinationEntity>(IEnumerable<TSourceEntity> source, IEnumerable<TDestinationEntity> destination)
                where TSourceEntity : class, IBaseEntity, new()
                where TDestinationEntity : class, IBaseEntity, new()
            => new ListTransaction<TSourceEntity, TDestinationEntity>(source: source, destination: destination);


        public static ListTransaction<TSourceEntity, TDestinationEntity>
            ListsEmpty<TSourceEntity, TDestinationEntity>()
                where TDestinationEntity : class, IBaseEntity, new()
                where TSourceEntity : class, IBaseEntity, new() =>
            new ListTransaction<TSourceEntity, TDestinationEntity>(source: default, destination: default);
    }
    public static class Transaction
    {
        public static Transaction<TSourceEntity, TDestinationEntity>
            DestinationEmpty<TSourceEntity, TDestinationEntity>(TSourceEntity source)
                where TDestinationEntity : class, IBaseEntity, new()
                where TSourceEntity : class, IBaseEntity, new()
            => new Transaction<TSourceEntity, TDestinationEntity>(source: source, destination: default);

        public static Transaction<TSourceEntity, TDestinationEntity>
          SourceEmpty<TSourceEntity, TDestinationEntity>(TDestinationEntity destination)
              where TDestinationEntity : class, IBaseEntity, new()
              where TSourceEntity : class, IBaseEntity, new()
          => new Transaction<TSourceEntity, TDestinationEntity>(destination: destination, source: default);

        public static Transaction<TSourceEntity, TDestinationEntity>
            Found<TSourceEntity, TDestinationEntity>(TSourceEntity source, TDestinationEntity destination)
                where TDestinationEntity : class, IBaseEntity, new()
                where TSourceEntity : class, IBaseEntity, new()
            => new Transaction<TSourceEntity, TDestinationEntity>(source: source,destination: destination);


        public static Transaction<TSourceEntity, TDestinationEntity>
            Empty<TSourceEntity, TDestinationEntity>()
                where TDestinationEntity : class, IBaseEntity, new()
                where TSourceEntity : class, IBaseEntity, new() =>
            new Transaction<TSourceEntity, TDestinationEntity>(source: default, destination: default);
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
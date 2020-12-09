using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Helpers
{
    public static class TransactionResponse
    {
        public static TransactionResponse<TSource, TDests> Success<TSource, TDests>(TSource source, TDests destination)
            where TSource : class, new()
            where TDests : class, new()
        {
            return new TransactionResponse<TSource, TDests>(source: source, destination: destination, errorMessages: default);
        }


        public static TransactionResponse<TSource, TDests> Error<TSource, TDests>(List<string> errorMessages)
            where TSource : class, new()
            where TDests : class, new()
        {
            return new TransactionResponse<TSource, TDests>(errorMessages: errorMessages, source: default, destination: default);
        }
    }

    public class TransactionResponse<TSource, TDests>
        where TSource : class, new()
        where TDests : class, new()
    {
        public TransactionResponse(TSource source, TDests destination, List<string> errorMessages)
        {
            this.source = source;
            Destination = destination;
            ErrorMessages = errorMessages;
        }

        public TSource source { get; set; }
       public TDests Destination { get; set; }
       public List<string> ErrorMessages { get; set; }
    }
}

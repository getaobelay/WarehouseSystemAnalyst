﻿using System.Collections.Generic;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Models
{
    public interface IQueryResponse<TModel>
        where TModel : class, new()
    {
        public TModel Model { get; set; }
        public IEnumerable<TModel> ModelList { get; set; }
        public bool Error { get; set; }
        string Message { get; set; }
    }
}

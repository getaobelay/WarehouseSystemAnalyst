﻿using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Mediator.Mapping;
using System;

namespace WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos
{
    public class PackageDto : IBaseDto, IMapFrom<Package>
    {
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Type { get; set; }
        public virtual ICollection<ProductPackageDto> ProductPackages { get; set; }
    }
}
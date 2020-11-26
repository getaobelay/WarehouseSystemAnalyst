using System.Collections.Generic;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos
{


    public class PackageDto
    {
        public string PackageID { get; set; }
        public string Type { get; set; }
        public IEnumerable<ProductPackagesDto> ProductPackages { get; set; }

    }
}
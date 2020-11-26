using System.Collections.Generic;

namespace WarehouseSystemAnalyst.Data.Models.Dtos.ProductDtos
{
    public class MesureDto
    {
        public string MesureID { get; set; }
        public string Measurement { get; set; }
        public IEnumerable<ProductMesuresDto> ProductMesures { get; set; }

    }
}
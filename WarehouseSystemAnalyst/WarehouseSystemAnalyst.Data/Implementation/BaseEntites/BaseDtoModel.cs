namespace WarehouseSystemAnalyst.Data.Implementation.BaseEntites
{
    public class BaseDtoModel
    {
        public int Id { get; set; }
        public string PK { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
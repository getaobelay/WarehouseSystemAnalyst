using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;
using WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;

namespace WarehouseSystemAnalyst.Data.Entities.ContactEntities
{
    public class Employee : BaseEntity
    {
        public Employee()
        {
            Transactions = new HashSet<EmployeeTransaction>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EmployeePK { get; set; }
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TransactionID { get; set; }
        public string MovementID { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<EmployeeTransaction> Transactions { get; set; }
    }
}
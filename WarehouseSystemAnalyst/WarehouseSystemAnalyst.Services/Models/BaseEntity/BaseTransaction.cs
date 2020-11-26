using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WarehouseSystemAnalyst.Services.Models.BaseEntity
{
    //TODO Move to a separated file
    public enum TransactionAction
    {
        Create,
        Delete,
        Update,
        Move,
    }

    public abstract class BaseTransaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionPK { get; set; }
        public string TransactionID { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public TransactionAction TransactionAction { get; set; }


    }
}

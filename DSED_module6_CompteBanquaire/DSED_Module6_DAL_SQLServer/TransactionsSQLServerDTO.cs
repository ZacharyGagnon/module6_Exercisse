using DSED_Module6_Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSED_Module6_DAL_SQLServer
{
    public class TransactionsSQLServerDTO
    {
        public int TransactionId { get; set; }
        public string Type { get; set; }
        public DateOnly Date { get; set; }
        public decimal Montant { get; set; }

        public TransactionsSQLServerDTO()
        {
            ;
        }
        public TransactionsSQLServerDTO(Transactions transaction)
        {
            TransactionId = transaction.TransactionId;
            Type = transaction.Type;
            Date = transaction.Date;
            Montant = transaction.Montant;
        }
        public Transactions VersEntite()
        {
            return new Transactions(TransactionId, Type, Date, Montant);
        }
    }
}

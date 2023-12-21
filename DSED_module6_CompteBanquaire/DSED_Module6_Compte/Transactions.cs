using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSED_Module6_Entite
{
    public class Transactions
    {
        public int TransactionId { get; private set; }
        public string Type { get; private set; }
        public DateOnly Date { get; private set; }
        public decimal Montant { get; private set; }

        public Transactions(int p_transactionId, string p_type, DateOnly p_date, decimal p_montant)
        {
            TransactionId = p_transactionId;
            Type = p_type;
            Date = p_date;
            Montant = p_montant;
        }
    }
}

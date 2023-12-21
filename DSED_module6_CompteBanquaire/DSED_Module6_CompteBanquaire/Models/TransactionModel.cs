using DSED_Module6_Entite;

namespace DSED_Module6_CompteBanquaire.Models
{
    public class TransactionModel
    {
        public int TransactionId { get; set; }
        public string Type { get; set; }
        public DateOnly Date { get; set; }
        public decimal Montant { get; set; }

        public TransactionModel()
        {
            ;
        }
        public TransactionModel(Transactions p_transaction)
        {
            TransactionId = p_transaction.TransactionId;
            Type = p_transaction.Type;
            Date = p_transaction.Date;
            Montant = p_transaction.Montant;
        }
        public Transactions VersEntite()
        {
            return new Transactions(TransactionId, Type, Date, Montant);
        }
    }
}

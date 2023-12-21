namespace DSED_Module6_Entite
{
    public class Compte
    {
        public int CompteId { get; private set; }
        public string Type { get; private set; }
        public List<Transactions>? Transactions { get; private set; }

        public Compte (int p_compteId, string p_type, List<Transactions>? p_transactions)
        {
            CompteId = p_compteId;
            Type = p_type;
            Transactions = p_transactions;
        }
    }
}
using DSED_Module6_Entite;

namespace DSED_Module6_CompteBanquaire.Models
{
    public class CompteModel
    {
        public int CompteId { get; set; }
        public string Type { get; set; }
        public List<Transactions>? Transactions { get; set; }

        public CompteModel()
        {
            ;
        }
        public CompteModel(Compte p_compte)
        {
            CompteId = p_compte.CompteId;
            Type = p_compte.Type;
            Transactions = p_compte.Transactions;
        }
        public Compte VersEntite()
        {
            return new Compte(CompteId, Type, Transactions);
        }
    }
}

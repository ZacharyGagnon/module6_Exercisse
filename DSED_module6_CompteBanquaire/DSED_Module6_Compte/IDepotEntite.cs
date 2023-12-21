using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DSED_Module6_Entite
{
    public interface IDepotEntite
    {
        public List<Compte> ListerComptes();
        public List<Transactions> ListerTransactions();
        public Compte RechercherCompte(int p_compteId);
        public void AjouterCompte(Compte p_compte);
        public void MAJCompte(Compte p_compte);
        public void AjouterTransaction(Transactions p_transaction);
        public Transactions RechercherTransaction(int p_transactionId);
    }
}

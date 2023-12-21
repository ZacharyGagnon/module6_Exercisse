using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSED_Module6_Entite
{
    public class ManipulationEntite 
    {
        IDepotEntite m_depotEntite;
        public ManipulationEntite(IDepotEntite p_depotEntite)
        {
            m_depotEntite = p_depotEntite;
        }
        public List<Compte> GetToutLesComptes()
        {
            return m_depotEntite.ListerComptes();
        }

        public List<Transactions> GetToutLesTransactions()
        {
            return m_depotEntite.ListerTransactions();
        }

        public Compte GetCompte(int p_compteId)
        {
            return m_depotEntite.RechercherCompte(p_compteId);
        }

        public void AjouterCompte(Compte p_compte)
        {
            m_depotEntite.AjouterCompte(p_compte);
        }

        public void MAJCompte(Compte p_compte)
        {
            m_depotEntite.MAJCompte(p_compte);
        }

        public void AjouterTransaction(Transactions p_transaction)
        {
            m_depotEntite.AjouterTransaction(p_transaction);
        }

        public Transactions RechercherTransaction(int p_transactionId)
        {
            return m_depotEntite.RechercherTransaction(p_transactionId);
        }
    }
}

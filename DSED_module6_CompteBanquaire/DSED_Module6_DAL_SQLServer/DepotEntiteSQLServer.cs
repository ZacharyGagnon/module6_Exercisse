using DSED_Module6_Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSED_Module6_DAL_SQLServer
{
    public class DepotEntiteSQLServer : IDepotEntite
    {
        private ContexteSQLServer m_contexte;

        public DepotEntiteSQLServer(ContexteSQLServer p_contexte)
        {
            if (p_contexte is null)
            {
                throw new ArgumentNullException(nameof(p_contexte));
            }
            m_contexte = p_contexte;
        }
        public List<Compte> ListerComptes()
        {
            return m_contexte.Compte.Select(compte => compte.VersEntite()).ToList();
        }
        public List<Transactions> ListerTransactions()
        {
            return m_contexte.Transactions.Select(transactions => transactions.VersEntite()).ToList();
        }
        public Compte RechercherCompte(int p_compteId)
        {
            return m_contexte.Compte.Where(compte => compte.CompteId == p_compteId).Select(compte => compte.VersEntite()).FirstOrDefault();
        }
        public void AjouterCompte(Compte p_compte)
        {
            if (p_compte is null)
            {
                throw new ArgumentNullException(nameof(p_compte));
            }

            if (m_contexte.Compte.Any(compte => compte.CompteId == p_compte.CompteId))
            {
                throw new InvalidOperationException($"La municipalité d'identifiant {p_compte.CompteId} existe déjà dans le dépôt de données.");
            }

            m_contexte.Compte.Add(new CompteSQLServerDTO(p_compte));
            this.m_contexte.SaveChanges();
        }
        public void MAJCompte(Compte p_compte)
        {
            if (p_compte is null)
            {
                throw new ArgumentNullException(nameof(p_compte));
            }

            if (!m_contexte.Compte.Any(compte => compte.CompteId == p_compte.CompteId))
            {
                throw new InvalidOperationException($"La municipalité d'identifiant {p_compte.CompteId} n'existe pas dans le dépôt de données.");
            }

            m_contexte.Compte.Update(new CompteSQLServerDTO(p_compte));
            this.m_contexte.SaveChanges();
        }
        public void AjouterTransaction(Transactions p_transaction)
        {
            if (p_transaction is null)
            {
                throw new ArgumentNullException(nameof(p_transaction));
            }

            if (!m_contexte.Transactions.Any(transaction => transaction.TransactionId == p_transaction.TransactionId))
            {
                throw new InvalidOperationException($"La municipalité d'identifiant {p_transaction.TransactionId} n'existe pas dans le dépôt de données.");
            }

            m_contexte.Transactions.Add(new TransactionsSQLServerDTO(p_transaction));
            this.m_contexte.SaveChanges();
        }
        public Transactions RechercherTransaction(int p_transactionId)
        {
            return m_contexte.Transactions.Where(transactions => transactions.TransactionId == p_transactionId).Select(transactions => transactions.VersEntite()).FirstOrDefault();
        }
    }
}

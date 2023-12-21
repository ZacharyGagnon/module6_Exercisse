using M06_CasUtlisation_Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_DAL_Client_SQLServer
{
    public class DepotClientSQLServer : IDepotClients
    {
        private ClientContexteSQLServer m_context;
        public DepotClientSQLServer(ClientContexteSQLServer p_context)
        {
            if (p_context is null)
            {
                throw new ArgumentNullException(nameof(p_context));
            }

            m_context = p_context;
        }
        public void AjouterClient(Client p_client)
        {
            if(p_client is null)
            {
                throw new ArgumentNullException("le client est null.");
            }
            if (m_context.Client.Any(c => c.ClientSQLDTOId == p_client.Identifiant))
            {
                throw new ArgumentException("Le client existe déjà dans la base de données.");
            }
            m_context.Client.Add(new ClientSQLServerDTO(p_client));
            m_context.SaveChanges();
        }
    }
}

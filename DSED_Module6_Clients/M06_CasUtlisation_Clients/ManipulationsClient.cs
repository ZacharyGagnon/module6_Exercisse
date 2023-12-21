using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_CasUtlisation_Clients
{
    public class ManipulationsClient
    {
        private IDepotClients DepotClients;

        public ManipulationsClient(IDepotClients p_depotClients)
        {
            DepotClients = p_depotClients;
        }
        public void AjouterClient(Client p_client)
        {
            DepotClients.AjouterClient(p_client);
        }
    }
}

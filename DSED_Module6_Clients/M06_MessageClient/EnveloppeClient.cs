using M06_CasUtlisation_Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_MessageClient
{
    public class EnveloppeClient
    {
        public string Action { get; set; }
        public string ActionId { get; set; }
        public MessageClient MessageClient { get; set; }

        public EnveloppeClient(string p_action, string p_actionId, MessageClient p_messageClient)
        {
            Action = p_action;
            ActionId = p_actionId;
            MessageClient = p_messageClient;
        }
    }
}

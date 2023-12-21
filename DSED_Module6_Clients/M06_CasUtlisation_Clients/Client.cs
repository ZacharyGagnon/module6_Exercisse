using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_CasUtlisation_Clients
{
    public class Client
    {
        public Guid Identifiant { get; private set; }
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public string Courriel { get; private set; }
        public string NumeroTelephone { get; private set; }

        public Client(Guid p_identifiant, string p_nom, string p_prenom, string p_courriel, string p_numeroTelephone)
        {
            Identifiant = p_identifiant;
            Nom = p_nom;
            Prenom = p_prenom;
            Courriel = p_courriel;
            NumeroTelephone = p_numeroTelephone;
        }
    }
}

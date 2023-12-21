using M06_CasUtlisation_Clients;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace M06_DAL_Client_SQLServer
{
    public class ClientSQLServerDTO
    {
        [Key]
        public Guid ClientSQLDTOId { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Courriel { get; set; }
        public string NumeroTelephone { get; set; }

        public ClientSQLServerDTO()
        {
            ;
        }
        public ClientSQLServerDTO(Client p_client)
        {
            ClientSQLDTOId = p_client.Identifiant;
            Prenom = p_client.Prenom;
            Nom = p_client.Nom;
            Courriel = p_client.Courriel;
            NumeroTelephone = p_client.NumeroTelephone;
        }
    }
}
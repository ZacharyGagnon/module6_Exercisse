using DSED_Module6_Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSED_Module6_DAL_SQLServer
{
    public class CompteSQLServerDTO
    {
        public int CompteId { get; set; }
        public string Type { get; set; }
        public List<Transactions>? Transactions { get; set; }

        public CompteSQLServerDTO()
        {
            ;
        }
        public CompteSQLServerDTO(Compte compte)
        {
            CompteId = compte.CompteId;
            Type = compte.Type;
            Transactions = compte.Transactions;
        }
        public Compte VersEntite()
        {
            return new Compte(CompteId, Type, Transactions);
        }
    }
}

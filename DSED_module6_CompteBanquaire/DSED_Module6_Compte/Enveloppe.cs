using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSED_Module6_Entite
{
    public class Enveloppe
    {
        public string TypeAction { get; set; }
        public string TypeEntite { get; set; }
        public Compte? Compte { get; set; }
        public Transactions? Transaction { get; set; }
    }
}

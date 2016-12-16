using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Kunde : Person
    {
        string kundenID;

        public Kunde(string kundenID, string firstname, string lastname, int age, DateTime birthdate) : base(firstname, lastname, age, birthdate)
        {
            if (kundenID != null)
                KundenID = "K" + kundenID;
            else
                throw new Exception("Jeder Kunde benötigt eine ID!");
        }

        public string KundenID
        {
            get
            {
                return kundenID;
            }

            set
            {
                kundenID = value;
            }
        }
    }
}

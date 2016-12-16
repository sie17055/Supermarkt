using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Kunde : Person
    {

        public Kunde(string kundenID, string firstname, string lastname, int age, DateTime birthdate) : base("K"+kundenID, firstname, lastname, age, birthdate)
        {
            
        }
    }
}

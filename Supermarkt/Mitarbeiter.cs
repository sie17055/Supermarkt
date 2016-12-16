using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Mitarbeiter : Person
    {

        public Mitarbeiter(string mitarbeiterID, string firstname, string lastname, int age, DateTime birthdate) : base("M" + mitarbeiterID, firstname, lastname, age, birthdate)
        {

        }
    }
}

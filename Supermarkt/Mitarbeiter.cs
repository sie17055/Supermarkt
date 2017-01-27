using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    public class Mitarbeiter : Person
    {
        public Mitarbeiter(string mitarbeiterID, string firstname, string lastname, int age, string address, Filiale filiale) : base("M" + mitarbeiterID, firstname, lastname, age, address, filiale)
        {
            if (age < 18)
                throw new Exception("Ein Mitarbeiter muss mindestens 18 Jahre alt sein!");
        }
    }
}

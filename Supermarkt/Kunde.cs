using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Kunde : Person
    {
        public Kunde(string firstname, string lastname, int age, DateTime birthdate) : base(firstname, lastname, age, birthdate)
        {
        }
    }
}

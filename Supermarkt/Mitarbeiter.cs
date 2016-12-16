using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Mitarbeiter : Person
    {
        string mitarbeiterID;

        public Mitarbeiter(string mitarbeiterID, string firstname, string lastname, int age, DateTime birthdate) : base(firstname, lastname, age, birthdate)
        {
            if (mitarbeiterID != null)
                MitarbeiterID = "M" + mitarbeiterID;
            else
                throw new Exception("Jeder Mitarbeiter benötigt eine ID!");
        }

        public string MitarbeiterID
        {
            get
            {
                return mitarbeiterID;
            }

            set
            {
                mitarbeiterID = value;
            }
        }
    }
}

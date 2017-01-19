using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Kunde : Person
    {
        Produkt lieblingsprodukt;
        public Kunde(string kundenID, string firstname, string lastname, int age, string address, Filiale filiale, Produkt lieblingsprodukt) : base("K"+kundenID, firstname, lastname, age, address, filiale)
        {
            if (age < 14)
                throw new Exception("Ein Kunde bekommt erst ab 14 Jahren eine Kundenkarte und wird damit registriert!");
            if (lieblingsprodukt != null)
                Lieblingsprodukt = lieblingsprodukt;
            else
                throw new Exception("Bitte geben Sie ein Produkt an!");
        }
        
        internal Produkt Lieblingsprodukt
        {
            get
            {
                return lieblingsprodukt;
            }

            set
            {
                lieblingsprodukt = value;
            }
        }
    }
}

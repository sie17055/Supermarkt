using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Kunde : Person
    {
        List<Produkt> gekaufteProdukte = new List<Produkt>();
        public Kunde(string kundenID, string firstname, string lastname, int age, string address, Filiale filiale) : base("K"+kundenID, firstname, lastname, age, address, filiale)
        {
            if (age < 14)
                throw new Exception("Ein Kunde bekommt erst ab 14 Jahren eine Kundenkarte!");
        }

        internal List<Produkt> GekaufteProdukte
        {
            get
            {
                return gekaufteProdukte;
            }

            set
            {
                gekaufteProdukte = value;
            }
        }
    }
}

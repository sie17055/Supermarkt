using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Kunde : Person
    {
        List<string> gekaufteProdukte;
        public Kunde(string kundenID, string firstname, string lastname, int age, string address, Filiale filiale, List<string> gekaufteProdukte) : base("K"+kundenID, firstname, lastname, age, address, filiale)
        {
            if (age < 14)
                throw new Exception("Ein Kunde bekommt erst ab 14 Jahren eine Kundenkarte und wird damit registriert!");
            if (gekaufteProdukte != null)
                GekaufteProdukte = gekaufteProdukte;
            else
                throw new Exception("Bitte geben Sie ein Produkt an!");
        }

        internal List<string> GekaufteProdukte
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

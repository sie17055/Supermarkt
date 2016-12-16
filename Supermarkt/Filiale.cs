using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Filiale
    {
        int filialID;
        string address;
        List<Mitarbeiter> mitarbeiter = new List<Mitarbeiter>();
        List<Kunde> kunden = new List<Kunde>();

        public Filiale(int filialID, string address)
        {
            if (filialID > 0)
                FilialID = filialID;
            else
                throw new Exception("Ungültige ID! (Filiale)");
            if (string.IsNullOrWhiteSpace(address))
                Address = address;
            else
                throw new Exception("Bitte geben Sie eine Addresse ein! (Filiale)");
        }

        public int FilialID
        {
            get
            {
                return filialID;
            }

            set
            {
                filialID = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        internal List<Mitarbeiter> Mitarbeiter
        {
            get
            {
                return mitarbeiter;
            }

            set
            {
                mitarbeiter = value;
            }
        }

        internal List<Kunde> Kunden
        {
            get
            {
                return kunden;
            }

            set
            {
                kunden = value;
            }
        }
    }
}

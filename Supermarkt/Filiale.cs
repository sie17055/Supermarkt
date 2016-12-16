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
        string adress;

        public Filiale(int filialID, string adress)
        {
            if (filialID > 0)
                FilialID = filialID;
            else
                throw new Exception("Ungültige ID! (Filiale)");
            if (adress != null)
                Adress = adress;
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

        public string Adress
        {
            get
            {
                return adress;
            }

            set
            {
                adress = value;
            }
        }
    }
}

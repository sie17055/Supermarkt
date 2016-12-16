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
        string adresse;

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

        public string Adresse
        {
            get
            {
                return adresse;
            }

            set
            {
                adresse = value;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Produkt
    {
        string id;
        string bezeichnung;
        float preis;
                
        public Produkt(string id, string bezeichnung, float preis)
        {
            if (!string.IsNullOrWhiteSpace(id))
                Id = id;
            else
                throw new Exception("Bitte geben Sie eine ID an!");

            if (!string.IsNullOrWhiteSpace(bezeichnung))
                Bezeichnung = bezeichnung;
            else
                throw new Exception("Bitte geben Sie eine Bezeichnung an!");

            //if (preis > 0.00)
            Preis = preis;
            //throw new Exception("Bitte geben Sie einen Preis > 0 an!");
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Bezeichnung
        {
            get
            {
                return bezeichnung;
            }

            set
            {
                bezeichnung = value;
            }
        }

        public float Preis
        {
            get
            {
                return preis;
            }

            set
            {
                preis = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "ID: " + Id + "\nBezeichnung: " + Bezeichnung + "\nPreis: " + Preis;
        }
    }
}

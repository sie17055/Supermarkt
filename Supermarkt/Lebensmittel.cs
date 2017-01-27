using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    public class Lebensmittel : Produkt
    {
        float gewicht;
        public Lebensmittel(string id, string bezeichnung, float gewicht, float preis) : base("L"+id, bezeichnung, preis)
        {
            if (gewicht > 0f)
                Gewicht = gewicht;
            else
                throw new Exception("Bitte geben Sie ein Gewicht > 0 Gramm an!");              
        }

        public float Gewicht
        {
            get
            {
                return gewicht;
            }

            set
            {
                gewicht = value;
            }
        }
    }
}

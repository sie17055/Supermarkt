using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Elektronikartikel : Produkt
    {
        float stromverbrauch;
        public Elektronikartikel(string id, string bezeichnung, float preis, float stromverbrauch) : base("E"+id, bezeichnung, preis)
        {
            if (stromverbrauch > 0f)
                Stromverbrauch = stromverbrauch;
            else
                throw new Exception("Bitte geben Sie einen Stromverbrauch > 0 kW/h an!");
        }

        public float Stromverbrauch
        {
            get
            {
                return stromverbrauch;
            }

            set
            {
                stromverbrauch = value;
            }
        }
    }
}

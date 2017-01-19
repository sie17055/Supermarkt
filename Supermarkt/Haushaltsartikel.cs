using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Haushaltsartikel : Produkt
    {
        string typ;
        public Haushaltsartikel(string id, string bezeichnung, float preis, string typ) : base("H"+id, bezeichnung, preis)
        {
            if(string.IsNullOrWhiteSpace(typ))
            {
                throw new Exception("Jeder Haushaltsartikel braucht einen Typen! (zB: Waschmittel, Seife)");
            } else
            {
                Typ = typ;
            }
        }

        public string Typ
        {
            get
            {
                return typ;
            }

            set
            {
                typ = value;
            }
        }
    }
}

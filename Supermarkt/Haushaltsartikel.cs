using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Haushaltsartikel : Produkt
    {
        public Haushaltsartikel(string id, string bezeichnung, float preis) : base("H"+id, bezeichnung, preis)
        {
        }
    }
}

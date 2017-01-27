using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Supermarkt
{
    class Program
    {
        static List<Filiale> filialen = new List<Filiale>();
        static List<Produkt> produkte = new List<Produkt>();
        static List<Mitarbeiter> mitarbeiter = new List<Mitarbeiter>();
        static List<Kunde> kunden = new List<Kunde>();
        static void Main(string[] args)
        {
            init();
            abfragen();
        }

        public static void init()
        {
            XDocument xFilialen = XDocument.Load("../..Filialen.xml");
            var data = from filiale in xFilialen.Descendants("Filiale")
                       select new
                       {
                           ID = filiale.Attribute("ID").Value,
                           Adresse = filiale.Element("Adresse").Value,
                           PLZ = filiale.Element("PLZ").Value
                       };
            foreach (var f in data)
            {
                Filiale f1 = new Filiale(int.Parse(f.ID), f.Adresse, f.PLZ);
                filialen.Add(f1);
            }

            try
            {
                       

                using (StreamReader srProdukte = new StreamReader("../../Produkte.csv")) // Produkte einlesen
                {
                    while (srProdukte.Peek() >= 0)
                    {
                        string line = srProdukte.ReadLine();
                        string[] lineParts = line.Split(';');
                        Produkt p = null;
                        switch (lineParts[0].First())
                        {
                            case 'E':
                                p = new Elektronikartikel(lineParts[0], lineParts[1], float.Parse(lineParts[2]), float.Parse(lineParts[3]));
                                break;
                            case 'H':
                                p = new Haushaltsartikel(lineParts[0], lineParts[1], float.Parse(lineParts[2]), lineParts[3]);
                                break;
                            case 'L':
                                p = new Lebensmittel(lineParts[0], lineParts[1], float.Parse(lineParts[2]), float.Parse(lineParts[3]));
                                break;
                        }
                        produkte.Add(p);
                    }
                }

                using (StreamReader srKunden = new StreamReader("../../kunden.csv")) // Kunden einlesen
                {
                    while (srKunden.Peek() >= 0)
                    {
                        string line = srKunden.ReadLine();
                        string[] lineParts = line.Split(';');
                        string products = lineParts[7];
                        List<string> gekaufteProdukte = products.Split(',').ToList();
                        Person p = new Kunde(lineParts[1], lineParts[2], lineParts[3], int.Parse(lineParts[4]), lineParts[5], filialen.ElementAt(int.Parse(lineParts[6])), gekaufteProdukte);
                        kunden.Add( (Kunde) p );
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine("FEHLER beim Lesen des Files: " + e.ToString());
            }
        }

        public static void abfragen()
        {
             
        }
    }
}

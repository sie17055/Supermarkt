using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        }

        public static void init()
        {
            try
            {
                using (StreamReader srFilialen = new StreamReader("../../Filialen.csv")) // Filialen einlesen
                {
                    while (srFilialen.Peek() >= 0)
                    {
                        string line = srFilialen.ReadLine();
                        string[] lineParts = line.Split(';');
                        Filiale f = new Filiale(int.Parse(lineParts[0]), lineParts[1], lineParts[2]);
                        filialen.Add(f);
                    }
                }

                using (StreamReader srProdukte = new StreamReader("../../Produkte.csv")) // Produkte einlesen
                {
                    while (srProdukte.Peek() >= 0)
                    {
                        string line = srProdukte.ReadLine();
                        string[] lineParts = line.Split(';');
                        Produkt p = null;
                        switch (lineParts[0])
                        {
                            case "Elektronik":
                                p = new Elektronikartikel(lineParts[1], lineParts[2], float.Parse(lineParts[3]), float.Parse(lineParts[4]));
                                break;
                            case "Haushalt":
                                p = new Haushaltsartikel(lineParts[1], lineParts[2], float.Parse(lineParts[3]), lineParts[4]);
                                break;
                            case "Lebensmittel":
                                p = new Lebensmittel(lineParts[1], lineParts[2], float.Parse(lineParts[3]), float.Parse(lineParts[4]));
                                break;
                        }
                        produkte.Add(p);
                    }
                }

                using (StreamReader srPersonen = new StreamReader("../../Personen.csv")) // Personen einlesen
                {
                    while (srPersonen.Peek() >= 0)
                    {
                        string line = srPersonen.ReadLine();
                        string[] lineParts = line.Split(';');
                        Person p = null;
                        switch (lineParts[0])
                        {
                            case "Kunde":
                                p = new Kunde(lineParts[1], lineParts[2], lineParts[3], int.Parse(lineParts[4]), lineParts[5], filialen.ElementAt(int.Parse(lineParts[6])), produkte.ElementAt(int.Parse(lineParts[7])));
                                kunden.Add( (Kunde) p );
                                break;
                            case "Mitarbeiter":
                                p = new Mitarbeiter(lineParts[1], lineParts[2], lineParts[3], int.Parse(lineParts[4]), lineParts[5], filialen.ElementAt(int.Parse(lineParts[6])));
                                mitarbeiter.Add( (Mitarbeiter) p );
                                break;
                        }
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine("FEHLER beim Lesen des Files: " + e.ToString());
            }
        }
    }
}

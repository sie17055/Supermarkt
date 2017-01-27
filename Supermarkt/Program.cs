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
        static List<Filiale> filialen = null;
        static List<Produkt> produkte = null;
        static List<Mitarbeiter> mitarbeiter = null;
        static List<Kunde> kunden = null;
        static void Main(string[] args)
        {
            filialen = new List<Filiale>();
            produkte = new List<Produkt>();
            mitarbeiter = new List<Mitarbeiter>();
            kunden = new List<Kunde>();
            init();
            abfragen();
        }

        public static void init()
        {
            XDocument xFilialen = XDocument.Load("../../Filialen.xml");
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
                        string products = lineParts[6];
                        List<string> gekaufteProdukte = products.Split(',').ToList();
                        Person p = new Kunde(lineParts[0], lineParts[1], lineParts[2], int.Parse(lineParts[3]), lineParts[4], filialen.ElementAt(int.Parse(lineParts[5])-1), gekaufteProdukte);
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
            var erg1 = from kunde in kunden // Alle Kunden unter 30
                       where kunde.Age < 30
                       select kunde;
            foreach (var item1 in erg1)
            {
                Console.WriteLine(item1.ToString());
                Console.WriteLine("*************************************");
            }

            Console.WriteLine("===========================================================");

            var erg2 = from kunde in kunden // Alle Kunden der Filiale '57 Alenup Heights' (ID=6)
                       where kunde.Filiale.FilialID == 6
                       select kunde;
            foreach (var item2 in erg2)
            {
                Console.WriteLine(item2.ToString());
                Console.WriteLine("*********************************");
            }

            // alle Kunden mit gleicher Adresse wie Supermarkt-Adresse

            foreach (var item3 in filialen)
            {
                foreach (var item3_2 in kunden)
                {
                    if (item3_2.Address.Equals(item3.Address))
                    {
                        Console.WriteLine(item3_2.ToString());
                        Console.WriteLine("Filialen-Adresse: " + item3.Address);
                        Console.WriteLine("******************************");
                    }
                }
            }

            var erg4 = from kunde in kunden // Meistgekauftes Produkt von Kunde 'Lucile Cohen'
                       where kunde.Firstname.Equals("Lucile") && kunde.Lastname.Equals("Cohen")
                       select new
                       {
                           Vorname = kunde.Firstname,
                           Nachname = kunde.Lastname,
                           Lieblingsprodukt = kunde.GekaufteProdukte
                       };            
            var counts = erg4.FirstOrDefault().Lieblingsprodukt.Distinct().ToDictionary( // Alle einzigartigen Elemente
                x => x, // Schlüssel auswählen (Wert selbst)
                x => erg4.FirstOrDefault().Lieblingsprodukt.Count(y => y == x) // Anzahl der Elemente ermitteln
                );
            KeyValuePair<string, int> max = new KeyValuePair<string, int>(); // Aktuell am meisten vorkommendes Element
            counts.LastOrDefault(x =>
            {
                if (x.Value > max.Value)
                    max = x;
                return x.Value > max.Value;
            }); // Letztes Element (größtes) auswählen

            Console.WriteLine("Meistgekaufte Produkte von '" + erg4.FirstOrDefault().Vorname + " " + erg4.FirstOrDefault().Nachname +"'");

            var counts2 = counts.OrderByDescending(x => x.Value);//Dictionary anhand der Anzahl absteigend ordnen

            int cnt = counts2.First().Value;//Maximale Anzahl
            foreach (var c in counts2)
            {
                if (c.Value >= cnt)//Ausgeben, wenn nicht kleiner als das letzte Element
                {
                    Console.WriteLine("Produkt: {0}  Anzahl: {1}", c.Key, c.Value);
                }
                else
                    break;//Schleife verlassen, weil alle großen Anzahlen ausgegeben wurden
            }

            Console.WriteLine("**********************************"); //teuerste Produkte jeder Gattung (Elektroartikel, Lebensmittel, Haushaltsartikel)

            var erg5 = from produkt in produkte
                       orderby produkt.Preis descending
                       group produkt by produkt.Id.Substring(0, 1) into res
                       select new
                       {
                           Gattung = res.Key,
                           Bezeichnung = res.FirstOrDefault().Bezeichnung,
                           Preis = res.FirstOrDefault().Preis
                       };

            foreach (var item5 in erg5)
            {
                Console.WriteLine(item5.ToString());
            }
        }
    }
}

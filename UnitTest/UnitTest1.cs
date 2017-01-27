using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarkt;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, ExpectedException(typeof(Exception))]
        public void TestKundeUnter14() // ein Kunde unter 14 Jahren bekommt keine Kundenkarte und wird somit nicht registriert
        {
            List<string> produkt = new List<string>();
            produkt.Add("H1");
            Kunde k = new Kunde("test", "Max", "Mustermann", 12, "Mustergasse", new Filiale(999, "Mustergasse", "4765"), produkt);
        }

        [TestMethod, ExpectedException(typeof(Exception))]
        public void TestFilialeOhneZIP()
        {
            Filiale f= new Filiale(999, "Mustergasse", null);
        }

        [TestMethod]
        public void TestAnzahlEingelesenerProdukte()
        {
            List<Produkt> produkte = new List<Produkt>();
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
            Assert.AreEqual(produkte.Count, 18);
        }

        [TestMethod]
        public void TestAnzahlEingelesenerFilialen()
        {
            List<Filiale> filialen = new List<Filiale>();
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
            Assert.AreEqual(filialen.Count, 10);
        }

        [TestMethod]
        public void TestAnzahlEingelesenerKunden()
        {
            List<Filiale> filialen = new List<Filiale>();
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

            List<Kunde> kunden = new List<Kunde>();
            using (StreamReader srKunden = new StreamReader("../../kunden.csv")) // Kunden einlesen
            {
                while (srKunden.Peek() >= 0)
                {
                    string line = srKunden.ReadLine();
                    string[] lineParts = line.Split(';');
                    string products = lineParts[6];
                    List<string> gekaufteProdukte = products.Split(',').ToList();
                    Person p = new Kunde(lineParts[0], lineParts[1], lineParts[2], int.Parse(lineParts[3]), lineParts[4], filialen.ElementAt(int.Parse(lineParts[5]) - 1), gekaufteProdukte);
                    kunden.Add((Kunde)p);
                }
            }
            Assert.AreEqual(kunden.Count, 1000);
        }
    }
}

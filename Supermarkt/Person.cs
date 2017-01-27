using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Person
    {
        string id;
        string firstname;
        string lastname;
        int age;
        string address;
        Filiale filiale;

        public Person(string id, string firstname, string lastname, int age, string address, Filiale filiale)
        {
            if (!string.IsNullOrWhiteSpace(id))
                Id = id;
            else
                throw new Exception("Bitte geben Sie eine ID an!");

            if (!string.IsNullOrWhiteSpace(firstname))
                Firstname = firstname;
            else
                throw new Exception("Bitte geben Sie einen Vornamen an!");

            if (!string.IsNullOrWhiteSpace(lastname))
                Lastname = lastname;
            else
                throw new Exception("Bitte geben Sie einen Nachnamen an!");

            Age = age;

            if (!string.IsNullOrWhiteSpace(address))
                Address = address;
            else
                throw new Exception("Bitte geben Sie eine Addresse an!");

            if (filiale == null)
                throw new Exception("Ungültige Filialen-ID!");
            else
            {
                Filiale = filiale;
            }

        }

        public string Firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
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

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        internal Filiale Filiale
        {
            get
            {
                return filiale;
            }

            set
            {
                filiale = value;
            }
        }

        public override string ToString()
        {
            return "Personen-ID: " + Id + "\nName: " + Firstname + " " + Lastname + "\nAlter: " + Age + "\nAdresse: " + Address + "\nFiliale: " + Filiale.FilialID;
        }
    }
}

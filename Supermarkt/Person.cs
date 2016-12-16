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
        DateTime birthdate;
        string address;

        public Person(string id, string firstname, string lastname, int age, DateTime birthdate, string address)
        {
            if (id != null)
                Id = id;
            else
                throw new Exception("Bitte geben Sie eine ID an!");

            if (firstname != null)
                Firstname = firstname;
            else
                throw new Exception("Bitte geben Sie einen Vornamen an!");

            if (lastname != null)
                Lastname = lastname;
            else
                throw new Exception("Bitte geben Sie einen Nachnamen an!");

            if (birthdate != null)
                Birthdate = birthdate;
            else
                throw new Exception("Bitte geben Sie ein Geburtsdatum an!");

            if (address != null)
                Address = address;
            else
                throw new Exception("Bitte geben Sie eine Addresse an!");
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

        public DateTime Birthdate
        {
            get
            {
                return birthdate;
            }

            set
            {
                birthdate = value;
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
    }
}

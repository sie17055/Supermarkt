using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarkt
{
    class Person
    {
        string firstname;
        string lastname;
        int age;
        DateTime birthdate;

        public Person(string firstname, string lastname, int age, DateTime birthdate)
        {
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
    }
}

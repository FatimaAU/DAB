using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonKartotek
{
    class Repository
    {

        public void addPerson(string fName, string mName, string lName, Contact contact)
        {
            using (var db = new KartotekContext())
            {
                //Create and save a new person

                var person = new Person {FirstName = fName, MiddleName = mName, LastName = lName, Contact = contact};
                db.Persons.Add(person);
                db.SaveChanges();

                //Display all people from the database
                var query = from b in db.Persons
                    orderby b.FirstName
                    select b;

                Console.WriteLine("All people in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.FirstName + " " + item.MiddleName + " " + item.LastName);
                }
            }

        }

        public void addCity(string cityName, string zipCode)
        {
            using (var db = new KartotekContext())
            {
                //Create and save a new person

                var city = new City {CityName = cityName, ZipCode = zipCode};
                db.Cities.Add(city);
                db.SaveChanges();

                //Display all people from the database
                var query = from c in db.Cities
                    orderby c.CityName
                    select c;

                Console.WriteLine("All people in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.CityName + " " + item.ZipCode);
                }
            }

        }


    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonKartotek
{
    class Repository
    {

        public void addPerson(string fName, string mName, string lName)
        {
            using (var db = new KartotekContext())
            {
                var person = new Person { FirstName = fName, MiddleName = mName, LastName = lName };
                db.Persons.Add(person);
                db.SaveChanges();

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
                var city = new City {CityName = cityName, ZipCode = zipCode};
                db.Cities.Add(city);
                db.SaveChanges();

                var query = from b in db.Cities
                    orderby b.CityName
                    select b;

                Console.WriteLine("All cities in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.CityName + " " + item.ZipCode);
                }
            }

        }


    }
}


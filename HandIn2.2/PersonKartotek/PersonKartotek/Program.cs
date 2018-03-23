using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonKartotek
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new KartotekContext())
            {
                Repository myRepository = new Repository();
                //myRepository.addPerson("Søren","Schou","Martinsen");
                //myRepository.addCity("England","8210");

                //Create and save a new person
                Console.Write("Enter a name for a new city: ");
                var name = Console.ReadLine();

                var city = new City { CityName = name };
                db.Cities.Add(city);
                db.SaveChanges();

                //Display all people from the database
                var query = from c in db.Cities
                    orderby c.CityName
                    select c;

                Console.WriteLine("All people in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.CityName);
                }

                //Console.WriteLine("Press any key to exit...");
                //Console.ReadKey();
            }
        }
    }
}

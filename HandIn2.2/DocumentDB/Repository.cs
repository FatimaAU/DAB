using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._2
{
    public class Repository
    {
        public void CreatePerson()
        {
            Person newPerson = new Person();
            Contact contact = new Contact();
            Address mainAddress = new Address();
            City city = new City();
            Telephone telephone = new Telephone();

            mainAddress.City = city;


            newPerson.Contact = contact;
            contact.

            Console.WriteLine("Creating new person\n");

            Console.Write("Enter id: ");
            newPerson.Id = Console.ReadLine();

            Console.Write("Enter firstname: ");
            newPerson.FirstName = Console.ReadLine();

            Console.Write("Enter middle name: ");
            newPerson.MiddleName = Console.ReadLine();

            Console.Write("Enter last name: ");
            newPerson.LastName = Console.ReadLine();

            Console.WriteLine("Enter mainaddress:\n");
            newPerson.Contact.MainAddress.Type = "Main";

            AddAdress(newPerson);

            Console.Write("Enter email: ");
            newPerson.Contact.Email = Console.ReadLine();

            Console.Write("Enter optional address (press enter if no optinals)");

            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                Console.WriteLine("Enter type:\n");
                //newPerson.Contact.MainAddress.Type = Console.ReadLine();

                AddAdress(newPerson);
            }

        }

        private void AddAdress(Person person)
        {
            Console.Write("Enter streetname: ");
            person.Contact.MainAddress.StreetName = Console.ReadLine();

            Console.Write("Enter house number: ");
            person.Contact.MainAddress.HouseNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter country: ");
            person.Contact.MainAddress.Country = Console.ReadLine();

        }
        private void AddToDatabase(Person person)
        {

        }
    }
}

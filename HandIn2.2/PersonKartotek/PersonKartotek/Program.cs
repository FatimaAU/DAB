using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using PersonKartotek.Core.Domain;
using PersonKartotek.Persistence;

namespace PersonKartotek
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopleToPrint = new List<Person>();

            // Start with changing mainaddress
            using (var unitOfWork = new UnitOfWork(new KartotekContext()))
            {
                var p = unitOfWork.Person.Get(19);
                p.Contact.MainAddress = unitOfWork.MainAddress.Get(17);
                unitOfWork.Complete();
            }

            //Get and print a person
            using (var unitOfWork = new UnitOfWork(new KartotekContext()))
            {
                Console.WriteLine("Get person with id 19 and print info:\n");

                peopleToPrint.Clear();

                var p = unitOfWork.Person.Get(19);

                peopleToPrint.Add(p);

                PrintPersonInfo(peopleToPrint);

                Console.WriteLine("Press any key");
                Console.ReadKey();
            }

            //Get a person and update his main address
            using (var unitOfWork = new UnitOfWork(new KartotekContext()))
            {
                Console.WriteLine("Get person with id 19 and changing his main address:\n");
                var p = unitOfWork.Person.Get(19);

                p.Contact.MainAddress = unitOfWork.MainAddress.Get(18);

                unitOfWork.Complete();
            }

            // Print him again
            using (var unitOfWork = new UnitOfWork(new KartotekContext()))
            {
                Console.WriteLine("Get person with id 19 and print info again:\n");
                peopleToPrint.Clear();

                var p = unitOfWork.Person.Get(19);

                peopleToPrint.Add(p);

                PrintPersonInfo(peopleToPrint);

                Console.WriteLine("Press any key");
                Console.ReadKey();
            }

            // Get him again and change mainaddress
            using (var unitOfWork = new UnitOfWork(new KartotekContext()))
            {
                Console.WriteLine("Get person with id 19 and change his address to match person with id 18\n");
                var p = unitOfWork.Person.Get(19);

                p.Contact.MainAddress = unitOfWork.MainAddress.GetMainAddressWithPerson(18);

                unitOfWork.Complete();
            }

            // Print him again
            using (var unitOfWork = new UnitOfWork(new KartotekContext()))
            {
                Console.WriteLine("Get person with id 19 and print info once again:\n");
                peopleToPrint.Clear();

                var p = unitOfWork.Person.Get(19);

                peopleToPrint.Add(p);

                PrintPersonInfo(peopleToPrint);

                Console.WriteLine("Press any key");
                Console.ReadKey();
            }

            using (var unitOfWork = new UnitOfWork(new KartotekContext()))
            {
                Console.WriteLine("PRINT ALL PEOPLE!!\n");
                peopleToPrint.Clear();

                var people = unitOfWork.Person.GetAll();
                PrintPersonInfo(people);
            }
        }

        static void PrintPersonInfo(IEnumerable<Person> p)
        {
            foreach (var person in p)
            {
                Console.WriteLine("Name: " + person.FirstName + " " + person.MiddleName + " " + person.LastName +
                                    "\nEmail: " + person.Contact.Email +
                                    "\nMainAddress: " + 
                                    "\n\tStreetname: " + person.Contact.MainAddress.Address.StreetName +
                                    "\n\tHousenumber: " + person.Contact.MainAddress.Address.HouseNumber +
                                    "\n\tCity: " + person.Contact.MainAddress.Address.City.CityName +
                                    "\n\tZipcode: " + person.Contact.MainAddress.Address.City.ZipCode +
                                    "\n\tCountry: " + person.Contact.MainAddress.Address.Country);

                Console.WriteLine("Alternative addresses:");
                foreach (var address in person.Contact.AlternativeAddresses)
                {
                    Console.WriteLine("\t" + address.Address.Type + ": " +
                                        "\n\t\tStreetname: " + address.Address.StreetName +
                                        "\n\t\tHousenumber: " + address.Address.HouseNumber +
                                        "\n\t\tCity: " + address.Address.City.CityName +
                                        "\n\t\tZipcode: " + address.Address.City.ZipCode +
                                        "\n\t\tCountry: " + address.Address.Country);
                }

                Console.WriteLine("Telephones:");
                foreach (var phone in person.Contact.Telephones)
                {
                    Console.WriteLine("\t" + phone.Type + ": " +
                                        "\n\t\tPhone number: " + phone.Number +
                                        "\n\t\tTelecompany: " + phone.TeleCompany);
                }

                Console.WriteLine("\n\n");
            }
        }
    }
}

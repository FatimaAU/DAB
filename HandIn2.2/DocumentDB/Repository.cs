using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2
{
    public class Repository
    {
        public Program Program;
        //private Person newPerson;
        private readonly DocumentClient _client;

        public Repository(DocumentClient client, Program program)
        {
            Program = program;
            _client = client;

        }
        public void CreatePerson()
        {
            Person newPerson = new Person();
            newPerson = new Person();
            Contact contact = new Contact();
            MainAddress mainAddress = new MainAddress();
            City city = new City();
            List<Telephone> telephones = new List<Telephone>();

            mainAddress.City = city;
            newPerson.Contact = contact;
            contact.MainAddress = mainAddress;

            Console.WriteLine("Creating new person\n");

            Console.Write("Enter id: ");
            newPerson.Id = Console.ReadLine();

            Console.Write("Enter firstname: ");
            newPerson.FirstName = Console.ReadLine();

            Console.Write("Enter middle name: ");
            newPerson.MiddleName = Console.ReadLine();

            Console.Write("Enter last name: ");
            newPerson.LastName = Console.ReadLine();

            Console.Write("Enter email: ");
            newPerson.Contact.Email = Console.ReadLine();

            Console.WriteLine("\nEnter mainaddress\n");

            Console.Write("Enter streetname: ");
            newPerson.Contact.MainAddress.StreetName = Console.ReadLine();

            Console.Write("Enter house number: ");
            newPerson.Contact.MainAddress.HouseNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter city name: ");
            newPerson.Contact.MainAddress.City.CityName = Console.ReadLine();

            Console.Write("Enter zip code: ");
            newPerson.Contact.MainAddress.City.ZipCode = Console.ReadLine();

            Console.Write("Enter country: ");
            newPerson.Contact.MainAddress.Country = Console.ReadLine();

            Console.WriteLine("Enter optional address (press enter if no optionals or any other key if optionals)");

            int counter = 0;

            List<Address> altAddresses = null;

            while (!string.IsNullOrEmpty(Console.ReadLine()))
            {
                if (altAddresses == null)
                    altAddresses = new List<Address>();

                Address newAddress = new Address();
                newAddress.City = new City();

                altAddresses.Add(newAddress);

                Console.Write("Enter streetname: ");
                altAddresses[counter].StreetName = Console.ReadLine();

                Console.Write("Enter house number: ");
                altAddresses[counter].HouseNumber= int.Parse(Console.ReadLine());

                Console.Write("Enter city name: ");
                altAddresses[counter].City.CityName = Console.ReadLine();

                Console.Write("Enter zip code: ");
                altAddresses[counter].City.ZipCode = Console.ReadLine();

                Console.Write("Enter country: ");
                altAddresses[counter].Country = Console.ReadLine();

                Console.Write("Enter type: ");
                altAddresses[counter].Type = Console.ReadLine();

                ++counter;

                Console.WriteLine("Enter optional address (press enter if no optionals or any other key if optionals)");
            }

            if (altAddresses != null)
            {
                counter = 0;
                Address[] addressArray = altAddresses.ToArray();
                newPerson.Contact.AlternateAddresses = addressArray;
            }

            do
            {
                telephones.Add(new Telephone());
                Console.Write("Enter telephone number: ");
                telephones[counter].Number = Console.ReadLine();

                Console.Write("Enter type: ");
                telephones[counter].Type = Console.ReadLine();

                Console.Write("Enter tele company: ");
                telephones[counter].TeleCompany = Console.ReadLine();

                counter++;
                
                Console.WriteLine("Enter alternative number (or press enter to exit)");


            } while (!string.IsNullOrEmpty(Console.ReadLine()));

            if (altAddresses != null)
            {
                Telephone[] telephoneArray = telephones.ToArray();
                newPerson.Contact.Telephones = telephoneArray;
            }

            AddToDatabase(newPerson);
        }

        private async void AddToDatabase(Person person)
        {
           Console.WriteLine("Adding person to database\n");
           await CreatePersonDocumentIfNotExists(Program.DatabaseId, Program.DatabaseId, person);
        }

        private async Task CreatePersonDocumentIfNotExists(string databaseName, string collectionName, Person person)
        {
            try
            {
                await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName,
                    person.Id));
                WriteToConsoleAndPromptToContinue("Found {0}", person.Id);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await _client.CreateDocumentAsync(
                        UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), person);
                    WriteToConsoleAndPromptToContinue("Created Person {0}", person.Id);
                }
                else
                {
                    throw;
                }
            }
        }

        private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

    }
}

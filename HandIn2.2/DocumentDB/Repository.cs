using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2
{
    public static class Repository
    {
        private const string EndpointUrl = "https://localhost:8081";

        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";   //Key for local DB emulator

        private static string DatabaseId = "PersonKartotek";    //Name of database and collection

        private static DocumentClient _client;

        public static async Task CreatePerson()
        {
            AddToDatabase(InitPerson());
        }

        // Makes a Person object for later use
        private static Person InitPerson()
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
            newPerson.Contact.MainAddress.HouseNumber = Console.ReadLine();

            Console.Write("Enter city name: ");
            newPerson.Contact.MainAddress.City.CityName = Console.ReadLine();

            Console.Write("Enter zip code: ");
            newPerson.Contact.MainAddress.City.ZipCode = Console.ReadLine();

            Console.Write("Enter country: ");
            newPerson.Contact.MainAddress.Country = Console.ReadLine();

            Console.WriteLine("Enter optional address (press enter if no optionals or any other key if optionals)");

            int counter = 0;    //Counter for alternative addresses

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
                altAddresses[counter].HouseNumber = Console.ReadLine();

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
                counter = 0;    //Reset counter for telephone
                Address[] addressArray = altAddresses.ToArray();    //Convert list to array
                newPerson.Contact.AlternateAddresses = addressArray;    //Add array to newperson
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


            } while (!string.IsNullOrEmpty(Console.ReadLine()));    //exit loop when no new alternative is wanted

            if (altAddresses != null)
            {
                Telephone[] telephoneArray = telephones.ToArray();
                newPerson.Contact.Telephones = telephoneArray;
            }

            return newPerson;
        }

        public static async Task ReadPerson(string databaseName, string collectionName)
        {
            Console.WriteLine("Enter person ID: ");
            string personID = Console.ReadLine();

            // Set some common query options
            FeedOptions queryOptions = new FeedOptions {MaxItemCount = -1};

            // Here we find the Person via its ID
            IQueryable<Person> personQuery = _client.CreateDocumentQuery<Person>(
                    UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), queryOptions)
                .Where(p => p.Id == personID);

            // Wanted person is now in PersonQuery
            foreach (Person person in personQuery)
            {
                Console.WriteLine("\tRead {0}", person);
            }
        }

        public static async Task UpdatePerson()
        {
            var newPerson = InitPerson();   //Create a new Person
            try
            {
                await ReplacePersonDocument(DatabaseId, DatabaseId, newPerson.Id, newPerson);   //Replace old person with new one
            }
            catch (Exception e)
            {
                Console.WriteLine("Person did not exist. Nothing has been updated.");   //When trying to update a person that does not exist
            }
        }

        public static async Task DeletePerson()
        {
            Console.WriteLine("Write Person ID for person to delete: ");
            string personId = Console.ReadLine();

            try
            {
               await DeletePersonDocument(DatabaseId, DatabaseId, personId);    //Deletes Person (document) with the wanted ID
            }
            catch (Exception e)
            {
                Console.WriteLine("Person does not exist. Nothing has been deleted");   //When Person doesn't exist
            }
        }


        //The following methods works directly with the database

        private static async Task ReplacePersonDocument(string databaseName, string collectionName, string personId, Person updatedPerson)
        {
            Console.WriteLine("ReplacePersonDocument()" + personId);
            await _client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, personId), updatedPerson);
            Console.WriteLine("Replaced Person {0}", personId);
        }

        private static async Task AddToDatabase(Person person)
        {
           await CreatePersonDocumentIfNotExists(DatabaseId, DatabaseId, person);
        }

        private static async Task DeletePersonDocument(string databaseName, string collectionName, string documentName)
        {
            await _client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, documentName));
            Console.WriteLine("Deleted Person {0}", documentName);
        }

        private static async Task CreatePersonDocumentIfNotExists(string databaseName, string collectionName, Person person)
        {
            try
            {
                await _client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName,
                    person.Id));
                Console.WriteLine("Person {0} exists already. Nothing created.", person.Id);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await _client.CreateDocumentAsync(
                        UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), person);
                    Console.WriteLine("Created Person {0}", person.Id);
                }
                else
                {
                    throw;
                }
            }
        }

        public static async Task InitializeDB()
        {
            _client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            await _client.CreateDatabaseIfNotExistsAsync(new Database { Id = DatabaseId });
            await _client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DatabaseId),
                new DocumentCollection { Id = DatabaseId });
        }
    }
}

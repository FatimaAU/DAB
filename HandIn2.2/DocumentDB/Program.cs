using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ADD THIS PART TO YOUR CODE
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace HandIn2._2
{
    class Program
    {
        // ADD THIS PART TO YOUR CODE
        private const string EndpointUrl = "https://localhost:8081";

        private const string PrimaryKey =
            "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        private DocumentClient client;

        static void Main(string[] args)
        {
            // ADD THIS PART TO YOUR CODE
            try
            {
                Program p = new Program();
                p.InitializeDB().Wait();
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message,
                    baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Console.WriteLine("End of shit, press any key to exit.");
                Console.ReadKey();
            }
        }

        public class Person
        {
            [JsonProperty(PropertyName = "id")] public string Id { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public Contact Contact { get; set; }

            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }


        public class Contact
        {
            public string Email { get; set; }
            public Address MainAddress { get; set; }
            public Address[] AlternateAddresses { get; set; }
            public Telephone[] Telephones { get; set; }
        }


        public class Telephone
        {
            public string Number { get; set; }
            public string Info { get; set; }
            public string TeleCompany { get; set; }
        }

        public class Address
        {
            public string StreetName { get; set; }
            public int HouseNumber { get; set; }
            public string Type { get; set; }
            public City City { get; set; }
            public string Country { get; set; }
        }

        public class City
        {
            public string CityName { get; set; }
            public string ZipCode { get; set; }
        }

        // ADD THIS PART TO YOUR CODE
        private async Task InitializeDB()
        {
            this.client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            await this.client.CreateDatabaseIfNotExistsAsync(new Database {Id = "PersonKartotek"});
            await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("PersonKartotek"),
                new DocumentCollection {Id = "PersonKartotek"});

            Person Søren = new Person
            {
                Id = "1",
                FirstName = "Søren",
                LastName = "Bachsen",
                Contact = new Contact
                {
                    MainAddress = new Address
                    {
                        City = new City
                        {
                            CityName = "Aarhus",
                            ZipCode = "8596"
                        },
                        Country = "Denmark",
                        HouseNumber = 45,
                        StreetName = "Bechvej",
                        Type = "Main"
                    },
                    Email = "Bech@bach.bech",
                    Telephones = new Telephone[]
                    {
                        new Telephone
                        {
                            Info = "Home",
                            Number = "01100101010001",
                            TeleCompany = "BachFone"
                        },
                        new Telephone
                        {
                            Info = "Work",
                            Number = "494875994",
                            TeleCompany = "BechBachTel"
                        },
                    },
                },
            };

            await this.CreatePersonDocumentIfNotExists("PersonKartotek", "PersonKartotek", Søren);
        }


        // ADD THIS PART TO YOUR CODE
        private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        private async Task CreatePersonDocumentIfNotExists(string databaseName, string collectionName, Person person)
        {
            try
            {
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName,
                    person.Id));
                this.WriteToConsoleAndPromptToContinue("Found {0}", person.Id);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(
                        UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), person);
                    this.WriteToConsoleAndPromptToContinue("Created Person {0}", person.Id);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

    public class Program
    {
        private const string EndpointUrl = "https://localhost:8081";

        private const string PrimaryKey =
            "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        public string DatabaseId = "PersonKartotek";

        public DocumentClient client;
        static public Program p;

        static void Main(string[] args)
        {
            try
            {
                p = new Program();
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

        private async Task InitializeDB()
        {
            this.client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            await this.client.CreateDatabaseIfNotExistsAsync(new Database {Id = DatabaseId});
            await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DatabaseId),
                new DocumentCollection {Id = DatabaseId});

            Menu();

            //Repository Repository = new Repository(client, p);


            //Repository.CreatePerson();

            //Repository.ReadPerson(DatabaseId, DatabaseId);

            //Repository.updatePerson();

            //Repository.DeletePerson();
            
            //Person Søren = new Person
            //{
            //    Id = "1",
            //    FirstName = "Søren",
            //    LastName = "Bachsen",
            //    Contact = new Contact
            //    {
            //        MainAddress = new Address
            //        {
            //            City = new City
            //            {
            //                CityName = "Aarhus",
            //                ZipCode = "8596"
            //            },
            //            Country = "Denmark",
            //            HouseNumber = 45,
            //            StreetName = "Bechvej",
            //            Type = "Main"
            //        },
            //        Email = "Bech@bach.bech",
            //        Telephones = new Telephone[]
            //        {
            //            new Telephone
            //            {
            //                Info = "Home",
            //                Number = "01100101010001",
            //                TeleCompany = "BachFone"
            //            },
            //            new Telephone
            //            {
            //                Info = "Work",
            //                Number = "494875994",
            //                TeleCompany = "BechBachTel"
            //            },
            //        },
            //    },
            //};

        }

        private void Menu()
        {
            Repository Repository = new Repository(client, p);

            while (true)
            {
                Console.WriteLine("Select task, 'C'reate, 'R'ead, 'U'pdate, 'D'elete:");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "C":
                        Repository.CreatePerson();
                        break;
                    case "R":
                        Repository.ReadPerson(DatabaseId, DatabaseId);
                        break;
                    case "U":
                        Repository.UpdatePerson();
                        break;
                    case "D":
                        Repository.DeletePerson();
                        break;
                    default:
                        Console.WriteLine("Only acceptable inputs are: 'C' 'R' 'U' 'D'");
                        break;
                }
            }
        }
    }
}

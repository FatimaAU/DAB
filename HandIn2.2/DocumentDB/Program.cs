using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2
{

    public class Program
    {
        private const string EndpointUrl = "https://localhost:8081";

        private const string PrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

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
            
            
        }

        private async Task InitializeDB()
        {
            this.client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
            await this.client.CreateDatabaseIfNotExistsAsync(new Database {Id = DatabaseId});
            await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(DatabaseId),
                new DocumentCollection {Id = DatabaseId});

            Menu();
        }

        private async Task Menu()
        {
            Repository Repository = new Repository(client, p);

            while (true)
            {
                Console.WriteLine("Select task, 'C'reate, 'R'ead, 'U'pdate, 'D'elete. Q to kvit:");
                string selection = Console.ReadLine().ToUpper();
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
                    case "Q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Only acceptable inputs are: 'C' 'R' 'U' 'D'");
                        break;
                }
            }
        }
    }
}

using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace HandIn2._2
{

    public class Program
    {
        public static Program p;

        static void Main(string[] args)
        {
            try
            {
                p = new Program();
                Repository.InitializeDB().Wait();
                Menu();
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


        private static void Menu()
        {
            //Stay in menu
            while (true)
            {
                Console.WriteLine("Select task, 'C'reate, 'R'ead, 'U'pdate, 'D'elete. Q to kvit:");
                string selection = Console.ReadLine().ToUpper();    //Get input and capitalize input
                switch (selection)
                {
                    case "C":
                        Repository.CreatePerson();
                        break;
                    case "R":
                        Repository.ReadPerson("PersonKartotek", "PersonKartotek");
                        break;
                    case "U":
                        Repository.UpdatePerson();
                        break;
                    case "D":
                        Repository.DeletePerson();
                        break;
                    case "Q":
                        Environment.Exit(0);    //Quit program
                        break;
                    default:
                        Console.WriteLine("Only acceptable inputs are: 'C' 'R' 'U' 'D'");
                        break;
                }
            }
        }
    }
}

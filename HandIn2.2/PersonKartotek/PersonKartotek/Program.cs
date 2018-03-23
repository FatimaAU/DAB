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
                myRepository.addPerson("Louise","Hansen", "Davidsen");
                System.Threading.Thread.Sleep(1000);
                myRepository.addCity("MartinByen","42069");



                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}

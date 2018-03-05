using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn2._1
{
    class Program
    {
        static void Main(string[] args)
        {

            Type male = new Type("Male");
            Telephone telephone1 = new Telephone(21351791, "Private telephone", "Telia");
            City aarhusV = new City("Aarhus V", "8210");
            City blacktown = new City("Blacktown", "CF3 7QG");
            Address address1 = new Address("HomeStreet", 39, aarhusV, "Private Address", "Danmark");
            Address address2 = new Address("Southend Avenue", 70, blacktown, "Work Address", "England");
            MainAddress mainAddress = new MainAddress(address1);
            AlternativeAddress altAddress = new AlternativeAddress(address2);
            Contact contact1 = new Contact("Bob@hotmail.com", telephone1, mainAddress, altAddress);

            Person person1 = new Person("Bob", "Martin", "Jensen", male, contact1);

            Display display1 = new Display(person1);
            foreach (var alts in person1.Contact.Alternatives.AltAddressList)
            {
                Console.WriteLine(alts.ToString());
                System.Console.WriteLine(alts.Type + ": " + alts.StreetName + " " + alts.HouseNumber + " " + alts.City.CityName + " " + alts.City.ZipCode + "\n");
            }

        }
    }
}

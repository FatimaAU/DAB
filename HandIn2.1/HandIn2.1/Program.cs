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
            Contact contact1 = new Contact("Bob@hotmail.com",telephone1);
            Address address1 = new Address("HomeStreet", 39, 8210, "Aarhus V.", "Private Address");
            Address address2 = new Address("WorkStreet", 12, 8240, "Risskov", "Work Address");
            MainAddress mainAddress = new MainAddress(address1);
            AlternativeAddress altAddress = new AlternativeAddress(address2);

            Person person1 = new Person("Bob", "Martin", "Jensen", male ,contact1 ,mainAddress, altAddress);

            Display display1 = new Display(person1);
            foreach (var alts in person1.AltAddress.AltAddressList)
            {
                Console.WriteLine(alts.ToString());
                System.Console.WriteLine(alts.Type + ": " + alts.StreetName + " " + alts.HouseNumber + " " + alts.City + " " + alts.ZipCode + "\n");
            }
            
        }
    }
}

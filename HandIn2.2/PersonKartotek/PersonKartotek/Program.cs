using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonKartotek
{
    partial class Program
    {
        static void Main(string[] args)
        {
            using (var db = new KartotekContext())
            {
                Telephone telephone1 = new Telephone("21351791", "Telia", "Private telephone");
                Telephone telephone2 = new Telephone("14113673", "Oister", "Work telephone");
                Telephone telephone3 = new Telephone("21351791", "3", "Mobile telephone");
                Telephone telephone4 = new Telephone("45455454", "Telia", "Private telephone");
                List<Telephone> bobTelephones = new List<Telephone>();
                List<Telephone> timTelephones = new List<Telephone>();
                bobTelephones.Add(telephone1);
                bobTelephones.Add(telephone2);
                bobTelephones.Add(telephone3);
                timTelephones.Add(telephone4);

                City aarhusV = new City("Aarhus V", "8210");
                City blacktown = new City("Blacktown", "CF3 7QG");
                City Kirkjubøur = new City("Kirkjubøur", "175");
                Address address1 = new Address("Kalendervej", 39, "Private Address", "Denmark", aarhusV);
                Address address2 = new Address("Southend Avenue", 70, "Work Address", "England", blacktown);
                Address address3 = new Address("Gamlivegur", 16, "Summer House", "Faroe Islands", Kirkjubøur);
                MainAddress mainAddress = new MainAddress(address1);
                AlternativeAddress altAddress1 = new AlternativeAddress(address2);
                AlternativeAddress altAddress2 = new AlternativeAddress(address3);
                List<AlternativeAddress> bobAltAddresses = new List<AlternativeAddress>();
                List<AlternativeAddress> timAltAddresses = new List<AlternativeAddress>();
                bobAltAddresses.Add(altAddress1);
                bobAltAddresses.Add(altAddress2);
                timAltAddresses.Add(altAddress2);

                Contact bobContact = new Contact("Bob@hotmail.com", bobTelephones, mainAddress, bobAltAddresses);
                Contact timContact = new Contact("Tim@Hotmail.com", timTelephones, mainAddress, timAltAddresses);

                Repository myRepository = new Repository();
                //myRepository.addPerson("Bob", "Martin", "Jensen", bobContact);
                //System.Threading.Thread.Sleep(1000);
                //myRepository.addPerson("Tim", "Martin", "Jensen", timContact);
                //myRepository.readCity();
                myRepository.deletePerson("Tim", "Jensen");
                //myRepository.readCity();




                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}

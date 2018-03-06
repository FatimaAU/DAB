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

            Telephone telephone1 = new Telephone(21351791, "Private telephone", "Telia");
            Telephone telephone2 = new Telephone(14113673, "Work telephone", "Oister");
            Telephone telephone3 = new Telephone(21351791, "Mobile telephone", "3");
            List<Telephone> telephones = new List<Telephone>();
            telephones.Add(telephone1);
            telephones.Add(telephone2);
            telephones.Add(telephone3);

            City aarhusV = new City("Aarhus V", "8210");
            City blacktown = new City("Blacktown", "CF3 7QG");
            City Kirkjubøur = new City("Kirkjubøur", "175");
            Address address1 = new Address("Kalendervej", 39, aarhusV, "Private Address", "Denmark");
            Address address2 = new Address("Southend Avenue", 70, blacktown, "Work Address", "England");
            Address address3 = new Address("Gamlivegur", 16, Kirkjubøur, "Summer House", "Faroe Islands");
            MainAddress mainAddress = new MainAddress(address1);
            List<AlternativeAddress> altAddresses = new List<AlternativeAddress>();
            AlternativeAddress altAddress1 = new AlternativeAddress(address2);
            AlternativeAddress altAddress2 = new AlternativeAddress(address3);
            altAddresses.Add(altAddress1);
            altAddresses.Add(altAddress2);

            Contact contact1 = new Contact("Bob@hotmail.com", telephones, mainAddress, altAddresses);

            Person person1 = new Person("Bob", "Martin", "Jensen", contact1);
            List<Person> personList = new List<Person>();
            personList.Add(person1);
            Kartotek myKartotek = new Kartotek(personList);

            foreach (var alts in myKartotek.PersonList)
            {
                Display display1 = new Display(alts);
            }

        }
    }
}

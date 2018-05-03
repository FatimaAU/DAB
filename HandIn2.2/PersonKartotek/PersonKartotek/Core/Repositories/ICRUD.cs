using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonKartotek.Core.Repositories
{
    public interface ICRUD
    {
        void addAddress(string streetName, int houseNumber, string type, string country, City city);
        void readAddress();
        void deleteAddress(string streetName, int houseNumber);

        void updateAddress(string removeStreetName, int removeHouseNumber, string streetName, int houseNumber,
            string type, string country, City city);

        void addAlternativeAddress(List<Contact> contacts, Address address);
        void addCity(string cityName, string zipCode);
        void readCity();
        void deleteCity(string cityName);
        void updateCity(string removeCityName, string cityName, string zipCode);

        void addContact(string email, List<Telephone> telephones, MainAddress mainAddress,
            List<AlternativeAddress> alternativeAddresses);

        void readContact();
        void deleteContact(string email);

        void updateContact(string deleteEmail, string addEmail, List<Telephone> telephones, MainAddress mainAddress,
            List<AlternativeAddress> alternativeAddresses);

        void addMainAddress(Address address);
        void addPerson(string fName, string mName, string lName, Contact contact);
        void readPerson();
        void deletePerson(string fName, string lName);

        void updatePerson(string removeFName, string removeLName, string addFName, string addMName, string addLName,
            Contact addContact);

        void addTelephone(string number, string teleCompany, string type);
        void readTelephone();
        void deleteTelephone(string number);
        void updateTelephone(string deleteNumber, string addNumber, string addTeleCompany, string addType);
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonKartotek
{
    class Repository
    {
        public void addAddress(string streetName, int houseNumber, string type, string country, City city)
        {
            using (var db = new KartotekContext())
            {
                var address = new Address(streetName, houseNumber, type, country, city) { StreetName = streetName, HouseNumber = houseNumber, Type = type, Country = country, City = city};
                db.Addresses.Add(address);
                db.SaveChanges();

                Console.WriteLine("Added Address\n");

                //var query = from b in db.Addresses
                //    orderby b.Type
                //    select b;

                //Console.WriteLine("All cities in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.Type + ": " + item.StreetName + item.HouseNumber + item.City.CityName + item.City.ZipCode + item.Country);
                //}
            }
        }

        public void addAlternativeAddress(List<Contact> contacts, Address address)
        {
            using (var db = new KartotekContext())
            {
                var alternativeAddress = new AlternativeAddress (/*contacts, */address) { /*Contacts = contacts, */Address = address};
                db.AlternativeAddresses.Add(alternativeAddress);
                db.SaveChanges();

                Console.WriteLine("Added AltAddress\n");
                //var query = from b in db.AlternativeAddresses
                //    orderby b.Address.City.CityName
                //    select b;

                //Console.WriteLine("All cities in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine();
                //}
            }
        }

        public void addCity(string cityName, string zipCode)
        {
            using (var db = new KartotekContext())
            {
                var city = new City(cityName, zipCode) { CityName = cityName, ZipCode = zipCode };
                db.Cities.Add(city);
                db.SaveChanges();

                Console.WriteLine("Added " + cityName + " " + zipCode + " to the database\n");
            }
        }

        public void readCity()
        {
            using (var db = new KartotekContext())
            {
                var query = from b in db.Cities
                orderby b.CityName
                select b;

                Console.WriteLine("All cities in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.CityName + " " + item.ZipCode);
                }
                
            }
        }

        public void deleteCity(string cityName)
        {
            using (var db = new KartotekContext())
            {
               City deletedCity = new City();
                deletedCity = (from c in db.Cities select c).FirstOrDefault();
                if (deletedCity.CityName == cityName)
                {
                    db.Cities.Remove(deletedCity);
                    db.SaveChanges();
                }

            }
        }

        public void updateCity()
        {
            using (var db = new KartotekContext())
            {
                
            }
        }

        public void addContact(string email, List<Telephone> telephones, MainAddress mainAddress, List<AlternativeAddress> alternativeAddresses)
        {
            using (var db = new KartotekContext())
            {
                var contact = new Contact (email, telephones, mainAddress, alternativeAddresses) { Email = email, Telephones = telephones, MainAddress = mainAddress, AlternativeAddresses = alternativeAddresses};
                db.Contacts.Add(contact);
                db.SaveChanges();

                Console.WriteLine("Added Contact\n");

                //var query = from b in db.Contacts
                //    orderby b.Email
                //    select b;

                //Console.WriteLine("All cities in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine();
                //}
            }
        }

        public void addMainAddress(Address address)
        {
            using (var db = new KartotekContext())
            {
                var mainAddress = new MainAddress (address) { Address = address};
                db.MainAddresses.Add(mainAddress);
                db.SaveChanges();

                Console.WriteLine("Added MainAddress\n");
                //var query = from b in db.MainAddresses
                //    orderby b.Address.City.CityName
                //    select b;

                //Console.WriteLine("All cities in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine();
                //}
            }
        }


        public void addPerson(string fName, string mName, string lName, Contact contact)
        {
            using (var db = new KartotekContext())
            {
                var person = new Person (fName, mName, lName, contact) { FirstName = fName, MiddleName = mName, LastName = lName, Contact = contact };
                db.Persons.Add(person);
                db.SaveChanges();

                Console.WriteLine("Added " + fName + " " + mName + " " + lName + " to the database\n");
            }
        }

        public void readPerson()
        {
            using (var db = new KartotekContext())
            {
                var query = from p in db.Persons
                    orderby p.FirstName
                    select p;

                Console.WriteLine("All people in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.FirstName + " " + item.MiddleName + " " + item.LastName);
                }
            }
        }

        public void deletePerson(string fName, string lName)
        {
            using (var db = new KartotekContext())
            {
                Person deletedPerson = new Person();
                //deletedPerson = (from c in db.Persons select c).Any()
                //bool isAName = db.Persons.Any(p => p.FirstName == fName && p.LastName == lName);
                var isAName = deletedPerson.FirstName.Select(f => f.ToString() == fName);

                if (deletedPerson.FirstName == fName && deletedPerson.LastName == lName)
                {
                    db.Persons.Remove(deletedPerson);
                    db.SaveChanges();
                }
            }
        }

        public void addTelephone(string number, string teleCompany, string type)
        {
            using (var db = new KartotekContext())
            {
                var telephone = new Telephone (number, teleCompany, type) { Number = number, TeleCompany = teleCompany, Type = type};
                db.Telephones.Add(telephone);
                db.SaveChanges();

                Console.WriteLine("Added Telephone\n");
                //var query = from b in db.Telephones
                //    orderby b.Type
                //    select b;

                //Console.WriteLine("All people in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine();
                //}
            }
        }


    }
}


using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

                
            }
        }

        public void readAddress()
        {
            using (var db = new KartotekContext())
            {
                var query = from b in db.Addresses
                            orderby b.Type
                            select b;

                Console.WriteLine("All addresses in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Type + ": " + item.StreetName + item.HouseNumber + item.City.CityName + item.City.ZipCode + item.Country);
                }
            }
        }

        public void deleteAddress(string streetName, int houseNumber)
        {
            using (var db = new KartotekContext())
            {
                var deletedAddress =
                    from p in db.Addresses
                    where p.StreetName == streetName && p.HouseNumber == houseNumber
                    select p;

                foreach (var address in deletedAddress)
                {
                    db.Addresses.Remove(address);
                    Console.WriteLine(address.StreetName + " " + address.HouseNumber + " is deleted from the database");
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void updateAddress(string removeStreetName, int removeHouseNumber, string streetName, int houseNumber, string type, string country, City city)
        {
            using (var db = new KartotekContext())
            {
                var deletedAddress =
                    from p in db.Addresses
                    where p.StreetName == removeStreetName && p.HouseNumber == removeHouseNumber
                    select p;

                foreach (var deladdress in deletedAddress)
                {
                    db.Addresses.Remove(deladdress);
                    Console.WriteLine(deladdress.StreetName + " " + deladdress.HouseNumber + " is deleted from the database");
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                var address = new Address(streetName, houseNumber, type, country, city) { StreetName = streetName, HouseNumber = houseNumber, Type = type, Country = country, City = city };
                db.Addresses.Add(address);
                db.SaveChanges();
                Console.WriteLine("Updated Contact from " + removeStreetName + " " + removeHouseNumber + " to " + streetName + " " + houseNumber);
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
                var deletedCity =
                    from p in db.Cities
                    where p.CityName == cityName
                    select p;

                foreach (var city in deletedCity)
                {
                    db.Cities.Remove(city);
                    Console.WriteLine(city.CityName + " is deleted from the database");
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void updateCity(string removeCityName, string cityName, string zipCode)
        {
            using (var db = new KartotekContext())
            {
                var deletedCity =
                    from p in db.Cities
                    where p.CityName == removeCityName
                    select p;

                foreach (var delcity in deletedCity)
                {
                    db.Cities.Remove(delcity);
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                var city = new City(cityName, zipCode) { CityName = cityName, ZipCode = zipCode };
                db.Cities.Add(city);
                db.SaveChanges();
                Console.WriteLine("Updated Contact from " + removeCityName + " to " + cityName);
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

                
            }
        }

        public void readContact()
        {
            using (var db = new KartotekContext())
            {
                var query = from b in db.Contacts
                            orderby b.Email
                            select b;

                Console.WriteLine("All contacts in the database:");
                foreach (var item in query)
                {
                    int totalAddresses = item.AlternativeAddresses.Count + 1;
                    Console.WriteLine("Email: " + item.Email + "\t Telephones: " + item.Telephones.Count + "\t Addresses: " + totalAddresses);
                }

            }
        }

        public void deleteContact(string email)
        {
            using (var db = new KartotekContext())
            {
                var deletedContact =
                    from p in db.Contacts
                    where p.Email == email
                    select p;

                foreach (var contact in deletedContact)
                {
                    db.Contacts.Remove(contact);
                    Console.WriteLine(contact.Email + " is deleted from the database");
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void updateContact(string deleteEmail, string addEmail, List<Telephone> telephones, MainAddress mainAddress, List<AlternativeAddress> alternativeAddresses)
        {
            using (var db = new KartotekContext())
            {
                var deletedContact =
                    from p in db.Contacts
                    where p.Email == deleteEmail
                    select p;

                foreach (var delcontact in deletedContact)
                {
                    db.Contacts.Remove(delcontact);
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                var contact = new Contact(addEmail, telephones, mainAddress, alternativeAddresses) { Email = addEmail, Telephones = telephones, MainAddress = mainAddress, AlternativeAddresses = alternativeAddresses };
                db.Contacts.Add(contact);
                db.SaveChanges();

                Console.WriteLine("Updated Contact from " + deleteEmail + " to " + addEmail);
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
                var deletedPerson =
                    from p in db.Persons
                    where p.FirstName == fName && p.LastName == lName
                    select p;

                foreach (var person in deletedPerson)
                {
                    db.Persons.Remove(person);
                    Console.WriteLine(person.FirstName + " " + person.LastName + " is deleted from the database");
                }
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void updatePerson(string removeFName, string removeLName, string addFName, string addMName, string addLName, Contact addContact)
        {
            using (var db = new KartotekContext())
            {
                var deletedPerson =
                    from p in db.Persons
                    where p.FirstName == removeFName && p.LastName == removeLName
                    select p;

                foreach (var person in deletedPerson)
                {
                    db.Persons.Remove(person);
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                var addedperson = new Person(addFName, addMName, addLName, addContact) { FirstName = addFName, MiddleName = addMName, LastName = addLName, Contact = addContact };
                db.Persons.Add(addedperson);
                db.SaveChanges();

                Console.WriteLine("Updated " + removeFName + " " + removeLName + "\n");
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

            }
        }

        public void readTelephone()
        {
            using (var db = new KartotekContext())
            {
                var query = from b in db.Telephones
                    orderby b.TelephoneId
                    select b;

                Console.WriteLine("All telephones in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Type + ": " + item.Number + " " + item.TeleCompany);
                }

            }
        }

        public void deleteTelephone(string number)
        {
            using (var db = new KartotekContext())
            {
                var deletedTelephone =
                    from p in db.Telephones
                    where p.Number == number
                    select p;

                foreach (var phone in deletedTelephone)
                {
                    db.Telephones.Remove(phone);
                    Console.WriteLine(phone.Number + " is deleted from the database");
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void updateTelephone(string deleteNumber, string addNumber, string addTeleCompany, string addType)
        {
            using (var db = new KartotekContext())
            {
                var deletedTelephone =
                    from p in db.Telephones
                    where p.Number == deleteNumber
                    select p;

                foreach (var phone in deletedTelephone)
                {
                    db.Telephones.Remove(phone);
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                var telephone = new Telephone(addNumber, addTeleCompany, addType) { Number = addNumber, TeleCompany = addTeleCompany, Type = addType };
                db.Telephones.Add(telephone);
                db.SaveChanges();

                Console.WriteLine("Updated Telephone from " + deleteNumber + " to " + addNumber + "\n");
            }
        }


    }
}


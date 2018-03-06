

using System;
using System.Diagnostics;
using System.Net.Http.Headers;


namespace HandIn2._1
{
    class Display
    {

        public Display(Person person)
        {

           Console.WriteLine("Name: " + person.FirstName + " " + person.MiddleName + " " + person.LastName);
            Console.WriteLine("Email: " + person.Contact.Email);
            foreach (var alts in person.Contact.Telephone)
            {
                Console.WriteLine(alts.Info + ":");
                Console.WriteLine("\tPhone number: " + alts.Number);
                Console.WriteLine("\tTelecompany: " + alts.TeleCompany + "\n");
            }
           
            Console.Write(person.Contact.MainAddress.Address.Type + ": "
                                                                  + person.Contact.MainAddress.Address.StreetName + " "
                                                                  + person.Contact.MainAddress.Address.HouseNumber + " ");

                switch (person.Contact.MainAddress.Address.Country)
                {
                    case "Denmark":
                        Console.WriteLine("DK" + " " + person.Contact.MainAddress.Address.City.ZipCode + " " + person.Contact.MainAddress.Address.City.CityName);
                        break;

                    case "England":
                        Console.WriteLine(person.Contact.MainAddress.Address.City.CityName + " " + person.Contact.MainAddress.Address.City.ZipCode + ", " + "UK");
                        break;

                    case "Faroe Islands":
                        Console.WriteLine("FO" + " " + person.Contact.MainAddress.Address.City.ZipCode + " " + person.Contact.MainAddress.Address.City.CityName);
                        break;
                }

            foreach (var alts in person.Contact.Alternatives)
            {
                Console.Write(alts.AltAddress.Type + ": "
                                        + alts.AltAddress.StreetName + " "
                                        + alts.AltAddress.HouseNumber + " ");

                switch (alts.AltAddress.Country)
                {
                    case "Denmark":
                        Console.WriteLine("DK" + " " + alts.AltAddress.City.ZipCode + " " + alts.AltAddress.City.CityName);
                        break;

                    case "England":
                        Console.WriteLine(alts.AltAddress.City.CityName + " " + alts.AltAddress.City.ZipCode + ", " + "UK");
                        break;

                    case "Faroe Islands":
                        Console.WriteLine("FO" + " " + alts.AltAddress.City.ZipCode + " " + alts.AltAddress.City.CityName);
                        break;
                }
            }
            Console.WriteLine("\n");
        }
    }
}
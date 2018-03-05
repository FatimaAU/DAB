

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
            Console.WriteLine("Type: " + person.Type.Types);
            Console.WriteLine("Email: " + person.Contact.Email);
            Console.WriteLine(person.Contact.Telephone.Info + ":");
            Console.WriteLine("\tPhone number: " + person.Contact.Telephone.Number);
            Console.WriteLine("\tTelecompany: " + person.Contact.Telephone.TeleCompany + "\n");            
            //Console.WriteLine(person..Address.Type + ": " + person.Address.Address.StreetName + " " + person.Address.Address.HouseNumber + " " + person.Address.Address.City + " " + person.Address.Address.ZipCode);
            Console.WriteLine(person.Contact.MainAddress.Address.Type + ": " 
                              + person.Contact.MainAddress.Address.StreetName + " " 
                              + person.Contact.MainAddress.Address.HouseNumber + " ");


            switch (person.Contact.MainAddress.Address.Country)
            {
                case "Danmark":
                    Console.WriteLine("DK" + " " + person.Contact.MainAddress.Address.ZipCode + " " + person.Contact.MainAddress.Address.City);
                    break;

                case "England":
                    Console.WriteLine("UK" + " " + person.Contact.MainAddress.Address.ZipCode + ", ");
                    break;

                case "Faroe Islands":
                    Console.WriteLine("FO" + " " + person.Contact.MainAddress.Address.ZipCode + " " + person.Contact.MainAddress.Address.City);
                    break;
            }

        }
    }
}
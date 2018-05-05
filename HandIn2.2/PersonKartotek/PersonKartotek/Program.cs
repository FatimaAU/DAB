﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using PersonKartotek.Core.Domain;
using PersonKartotek.Persistence;

namespace PersonKartotek
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new KartotekContext()))
            {

                var person = new Person
                {
                    FirstName = "Hans",
                    MiddleName = "Philip",
                    LastName = "Sørensen",
                    Contact =
                    {
                        MainAddress = unitOfWork.MainAddress.GetMainAddressWithPerson(16),
                        Email = "hans_s@gmail.com",
                        AlternativeAddresses = null,
                        Telephones = new List<Telephone>()
                    }
                };

                var t = new Telephone
                {
                    Number = "33239320",
                    TeleCompany = "CBB",
                    Type = "Privat"
                };

                person.Contact.Telephones.Add(t);

                //var mainad = unitOfWork.MainAddress.GetMainAddressWithPerson(17);

                //Console.WriteLine(person.Contact);
                //Console.WriteLine(person.Contact.MainAddress.Address.StreetName);

                unitOfWork.Person.Add(person);

                unitOfWork.Complete();
                //Console.ReadLine();

                //var c = unitOfWork.Address.GetAddressesWithCity(44);
                //foreach (var address in c)
                //{
                //    Console.WriteLine(address.StreetName);
                //}

                // person.Contact.MainAddress = unitOfWork.MainAddress.Get(15);

                //person.Contact.AlternativeAddresses = unitOfWork.AlternativeAddress.GetAlternativeAddressWithContacts("")

                //Console.WriteLine(person.Contact.MainAddress.Address.StreetName);
                //unitOfWork.Address.Find(b => b.)
                //    EnvironmentVariableTa
                //unitOfWork.Address.
                //person.Contact.MainAddress = unitOfWork.Address.
                //Telephone telephone1 = new Telephone("21351791", "Telia", "Private telephone");
                //Telephone telephone2 = new Telephone("14113673", "Oister", "Work telephone");
                //Telephone telephone3 = new Telephone("75431358", "3", "Mobile telephone");
                //Telephone telephone4 = new Telephone("45455454", "Telia", "Private telephone");
                //Telephone telephone5 = new Telephone("11112222", "Telia", "Private telephone");
                //List<Telephone> bobTelephones = new List<Telephone>();
                //List<Telephone> bobTelephones2 = new List<Telephone>();
                //List<Telephone> timTelephones = new List<Telephone>();
                //bobTelephones.Add(telephone1);
                //bobTelephones.Add(telephone2);
                //bobTelephones.Add(telephone3);
                //timTelephones.Add(telephone4);
                //bobTelephones2.Add(telephone5);

                //City aarhusV = new City("Aarhus V", "8210");
                //City blacktown = new City("Blacktown", "CF3 7QG");
                //City Kirkjubøur = new City("Kirkjubøur", "175");
                //City BobTown = new City("BobTown", "13013");
                //City Stockholm = new City("Stockholm", "11121");
                //Address address1 = new Address("Kalendervej", 39, "Private Address", "Denmark", aarhusV);
                //Address address2 = new Address("Southend Avenue", 70, "Work Address", "England", blacktown);
                //Address address3 = new Address("Gamlivegur", 16, "Summer House", "Faroe Islands", Kirkjubøur);
                //Address address4 = new Address("Bobstreet", 130, "Private Address", "Denmark", BobTown);
                //Address address5 = new Address("Norrmalm", 49, "Summer House", "Sweden", Stockholm);
                //MainAddress mainAddress = new MainAddress(address1);
                //MainAddress mainAddress2 = new MainAddress(address4);
                //AlternativeAddress altAddress1 = new AlternativeAddress(address2);
                //AlternativeAddress altAddress2 = new AlternativeAddress(address3);
                //AlternativeAddress altAddress3 = new AlternativeAddress(address5);
                //List<AlternativeAddress> bobAltAddresses = new List<AlternativeAddress>();
                //List<AlternativeAddress> bobAltAddresses2 = new List<AlternativeAddress>();
                //List<AlternativeAddress> timAltAddresses = new List<AlternativeAddress>();
                //bobAltAddresses.Add(altAddress1);
                //bobAltAddresses.Add(altAddress2);
                //bobAltAddresses2.Add(altAddress3);
                //timAltAddresses.Add(altAddress2);

                //Contact bobContact = new Contact("Bob@hotmail.com", bobTelephones, mainAddress, bobAltAddresses);
                //Contact bobContact2 = new Contact("Bob2@hotmail.com", bobTelephones2, mainAddress2, bobAltAddresses2);
                //Contact timContact = new Contact("Tim@Hotmail.com", timTelephones, mainAddress, timAltAddresses);


                //var person = unitOfWork.Person.GetPersonWithContact(16);
                //var cities = unitOfWork.Address.GetAll();
                //var city = unitOfWork.Address.Get(44);
                //var altAddress = unitOfWork.AlternativeAddress.Get(14);
                //unitOfWork.Complete();
            }
        }
    }
}

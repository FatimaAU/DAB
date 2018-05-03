using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HandIn3._2.Models
{
    public class PeopleDTO
    {
        //Person
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        //Contact
        public string Email { get; set; }

        ////Telephone
        //public string TelephoneNumber { get; set; }
        //public string TeleCompany { get; set; }
        //public string TelephoneType { get; set; }

        ////Address
        //public string StreetName { get; set; }
        //public int HouseNumber { get; set; }
        //public string Country { get; set; }
        //public string AddressType { get; set; }

        ////City
        //public string CityName { get; set; }
        //public string ZipCode { get; set; }
    }
}
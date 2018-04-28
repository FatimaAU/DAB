using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Handin3_2.Models
{
    public class PeopleDetailDTO
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        //Contact
        public string Email { get; set; }

        //Telephone
        public IEnumerable<TelephonesDTO> Telephones { get; set; }

        //AlternativeAddresses
        public IEnumerable<AddressesDTO> AltAddresses { get; set; }

        //Address
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string Country { get; set; }
        public string AddressType { get; set; }

        //City
        public string CityName { get; set; }
        public string ZipCode { get; set; }
    }
}
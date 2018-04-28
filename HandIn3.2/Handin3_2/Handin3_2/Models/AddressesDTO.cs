using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Handin3_2.Models
{
    public class AddressesDTO
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }
    }
}
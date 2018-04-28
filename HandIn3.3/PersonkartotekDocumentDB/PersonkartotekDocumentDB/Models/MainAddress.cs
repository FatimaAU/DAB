using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonkartotekDocumentDB.Models
{
    public class MainAddress
    {
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public City City { get; set; }
        public string Country { get; set; }
    }
}
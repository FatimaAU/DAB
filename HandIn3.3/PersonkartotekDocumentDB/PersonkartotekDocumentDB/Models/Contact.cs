using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonkartotekDocumentDB.Models
{
    public class Contact
    {
        public string Email { get; set; }
        public MainAddress MainAddress { get; set; }
        public Address[] AlternateAddresses { get; set; }
        public Telephone[] Telephones { get; set; }
    }
}
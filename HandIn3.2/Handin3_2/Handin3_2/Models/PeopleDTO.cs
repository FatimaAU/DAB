using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Handin3_2.Models
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
    }
}
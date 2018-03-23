using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonKartotek
{
    public class Person
    {
        //public Person(string fName, string mName, string lName,
        //    Contact contact)
        //{
        //    FirstName = fName;
        //    MiddleName = mName;
        //    LastName = lName;
        //    Contact = contact;
        //}
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
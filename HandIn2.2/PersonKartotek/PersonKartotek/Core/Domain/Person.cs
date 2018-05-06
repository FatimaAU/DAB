using System.ComponentModel.DataAnnotations;

namespace PersonKartotek.Core.Domain
{
    public class Person
    {
        public Person()
        {
            //Contact = new Contact();
        }
        
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace PersonKartotek
{
    public class Telephone
    {
        //public Telephone(string number, string teleCompany, Contact contact)
        //{
        //    Number = number;
        //    TeleCompany = teleCompany;
        //    Contact = contact;
        //}
        [Key]
        public int TelephoneId { get; set; }
        public string Number { get; set; }

        public string TeleCompany { get; set; }
        public virtual Contact Contact { get; set; }

    }
}
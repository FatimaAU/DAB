using System.ComponentModel.DataAnnotations;

namespace PersonKartotek
{
    public class Telephone
    {
        public Telephone() { }
        public Telephone(string number, string teleCompany, string type)
        {
            Number = number;
            TeleCompany = teleCompany;
            Type = type;
            //Contact = contact;
        }
        [Key]
        public int TelephoneId { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public string TeleCompany { get; set; }
        //public virtual Contact Contact { get; set; }

    }
}
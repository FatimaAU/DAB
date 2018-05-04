using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PersonKartotek
{
    public class Telephone
    {
        public Telephone()
        {

        }
        
        [Key]
        public int TelephoneId { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public string TeleCompany { get; set; }
        //public virtual Contact Contact { get; set; }

    }
}
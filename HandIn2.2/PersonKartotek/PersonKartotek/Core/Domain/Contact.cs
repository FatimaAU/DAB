using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonKartotek.Core.Domain
{
    public class Contact
    {
        public Contact()
        {

        }
        
        [Key]
        public string Email { get; set; }
        public virtual List<Telephone> Telephones { get; set; }
        public virtual MainAddress MainAddress { get; set; }
        public virtual List<AlternativeAddress> AlternativeAddresses { get; set; }
    }
}
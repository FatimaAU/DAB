using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonKartotek.Core.Domain
{
    public class Contact
    {
        public Contact()
        {
            Telephones = new HashSet<Telephone>();
            AlternativeAddresses = new HashSet<AlternativeAddress>();
        }
        
        [Key]
        public string Email { get; set; }
        public virtual ICollection<Telephone> Telephones { get; set; }
        public virtual MainAddress MainAddress { get; set; }
        public virtual ICollection<AlternativeAddress> AlternativeAddresses { get; set; }
    }
}
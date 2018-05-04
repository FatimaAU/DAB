using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonKartotek.Core.Domain
{
    public class AlternativeAddress
    {
        public AlternativeAddress() { }
        public AlternativeAddress(Address address)
        {
            Address = address;
        }
        [Key]
        public int AlternativeAddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Contact> Contacts { get; set; }
    }
}
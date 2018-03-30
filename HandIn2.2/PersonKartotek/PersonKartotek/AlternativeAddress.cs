using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonKartotek
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
    }
}
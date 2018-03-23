using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonKartotek
{
    public class AlternativeAddress
    {
        //public AlternativeAddress(List<Contact> contacts, Address address)
        //{
        //    Contacts = contacts;
        //    Address = address;
        //}
        [Key]
        public int AlternativeAddressId { get; set; }
        public virtual List<Contact> Contacts { get; set; }
        public virtual Address Address { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonKartotek.Core.Domain
{
    public class MainAddress
    {
        public MainAddress()
        {

        }
        
        [Key]
        public int MainAddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual List<Contact> Contacts { get; set; }

    }
}
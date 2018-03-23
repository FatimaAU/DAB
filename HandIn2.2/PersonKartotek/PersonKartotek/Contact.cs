using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonKartotek
{
    public class Contact
    {
        //public Contact(string email, List<Telephone> telephones, MainAddress mainAddress,
        //    List<AlternativeAddress> alternativeAddresses)
        //{
        //    Email = email;
        //    Telephones = telephones;
        //    MainAddress = mainAddress;
        //    AlternativeAddresses = alternativeAddresses;
        //}
        [Key]
        public string Email { get; set; }
        public virtual List<Telephone> Telephones { get; set; }
        public virtual MainAddress MainAddress { get; set; }
        public virtual List<AlternativeAddress> AlternativeAddresses { get; set; }
    }
}
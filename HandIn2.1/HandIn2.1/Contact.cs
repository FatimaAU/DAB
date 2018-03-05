using System.Collections.Generic;

namespace HandIn2._1
{
    class Contact
    {
        public Contact(string email, List<Telephone> telephone, MainAddress mainAddress, List<AlternativeAddress> alts)
        {
            Email = email;
            Telephone = telephone;
            MainAddress = mainAddress;
            Alternatives = alts;

        }
        public string Email { get; set; }
        public List<Telephone> Telephone = new List<Telephone>();
        public MainAddress MainAddress { get; set; }
        public List<AlternativeAddress> Alternatives = new List<AlternativeAddress>();
    }
}
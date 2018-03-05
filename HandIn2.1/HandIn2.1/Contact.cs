namespace HandIn2._1
{
    class Contact
    {
        public Contact(string email, Telephone telephone, MainAddress mainAddress, AlternativeAddress alts)
        {
            Email = email;
            Telephone = telephone;
            MainAddress = mainAddress;
            Alternatives = alts;

        }
        public string Email { get; set; }
        public Telephone Telephone { get; set; }
        public MainAddress MainAddress { get; set; }
        public AlternativeAddress Alternatives { get; set; }
    }
}
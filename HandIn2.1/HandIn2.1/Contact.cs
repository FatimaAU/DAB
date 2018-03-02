namespace HandIn2._1
{
    class Contact
    {
        public Contact(string email, Telephone telephone)
        {
            Email = email;
            Telephone = telephone;
        }
        public string Email { get; set; }
        public Telephone Telephone { get; set; }
    }
}
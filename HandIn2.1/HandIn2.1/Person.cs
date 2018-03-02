namespace HandIn2._1
{
    class Person
    {
        public Person(string fName, string mName, string lName, Type type, 
            Contact contactInfo, MainAddress address, AlternativeAddress alts)
        {
            FirstName = fName;
            MiddleName = mName;
            LastName = lName;
            Type = type;
            Contact = contactInfo;
            Address = address;
            AltAddress = alts;
        }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Type Type { get; set; }
        public Contact Contact { get; set; }
        public MainAddress Address { get; set; }
        public AlternativeAddress AltAddress { get; set; }
    }
}
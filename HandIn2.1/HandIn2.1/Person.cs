namespace HandIn2._1
{
    class Person
    {
        public Person(string fName, string mName, string lName, 
            Contact contactInfo)
        {
            FirstName = fName;
            MiddleName = mName;
            LastName = lName;
            Contact = contactInfo;
        }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Type Type { get; set; }
        public Contact Contact { get; set; }
    }
}
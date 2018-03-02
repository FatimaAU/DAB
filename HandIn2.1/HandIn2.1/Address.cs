namespace HandIn2._1
{
    class Address
    {

        public Address(string streetName, int houseNumber, int zipCode, string city, string type)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
            ZipCode = zipCode;
            City = city;
            Type = type;
        }



        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
    }
}
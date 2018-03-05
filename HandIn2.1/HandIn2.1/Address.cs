namespace HandIn2._1
{
    partial class Address
    {

        public Address(string streetName, int houseNumber, City city, string type, string country)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
            City = city;
            Type = type;
            Country = country;
        }



        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public City City { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace PersonKartotek
{
    public class Address
    {
        public Address() { }
        public Address(string streetName, int houseNumber, string type, string country, City city)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
            type = Type;
            City = city;
            Country = country;
        }
        [Key]
        public int AddressId { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public virtual City City { get; set; }
    }
}
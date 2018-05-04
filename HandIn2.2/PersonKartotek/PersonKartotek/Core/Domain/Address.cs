using System.ComponentModel.DataAnnotations;

namespace PersonKartotek
{
    public class Address
    {
        public Address()
        {

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
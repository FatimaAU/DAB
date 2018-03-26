using System.ComponentModel.DataAnnotations;

namespace PersonKartotek
{
    public class City
    {
        public City() { }
        public City(string name, string zipcode)
        {
            CityName = name;
            ZipCode = zipcode;
        }

        [Key]
        public int CityId { get; set; }
        public string ZipCode { get; set; } 
        public string CityName { get; set; }
    }
}
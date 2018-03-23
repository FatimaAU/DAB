using System.ComponentModel.DataAnnotations;

namespace PersonKartotek
{
    public class City
    {
        //public City(string name, string zipcode)
        //{
        //    CityName = name;
        //    ZipCode = zipcode;
        //}

        [Key]
        public string ZipCode { get; set; } 
        public string CityName { get; set; }
    }
}
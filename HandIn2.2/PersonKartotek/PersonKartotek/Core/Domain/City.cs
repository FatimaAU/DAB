using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonKartotek.Core.Domain
{
    public class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        [Key]
        public int CityId { get; set; }
        public string ZipCode { get; set; } 
        public string CityName { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace PersonKartotek
{
    public class MainAddress
    {
        public MainAddress() { }
        public MainAddress(Address address)
        {
            Address = address;
        }
        [Key]
        public int MainAddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
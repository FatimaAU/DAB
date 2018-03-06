using System.Collections.Generic;


namespace HandIn2._1
{
    class AlternativeAddress
    {
        public AlternativeAddress(Address address = null)
        {
            AltAddress = address;
        }

        public Address AltAddress { get; set; }
    }
}
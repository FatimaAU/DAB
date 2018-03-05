using System.Collections.Generic;


namespace HandIn2._1
{
    class AlternativeAddress
    {
        public AlternativeAddress(Address address = null)
        {
            AltAddressList = address;
        }

        public Address AltAddressList { get; set; }
    }
}
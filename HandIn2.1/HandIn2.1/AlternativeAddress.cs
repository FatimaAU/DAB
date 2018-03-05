using System.Collections.Generic;


namespace HandIn2._1
{
    class AlternativeAddress
    {
        public AlternativeAddress(Address address = null)
        {
            AltAddressList.Add(address);
        }

        public List<Address> AltAddressList = new List<Address>();
    }
}
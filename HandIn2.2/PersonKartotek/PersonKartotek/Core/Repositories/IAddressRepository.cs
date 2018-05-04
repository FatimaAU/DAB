using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonKartotek.Core.Domain;

namespace PersonKartotek.Core.Repositories
{
    public interface IAddressRepository : IRepository<Address>
    {
        Address GetCityWithAddresses(int id);
    }
    
}

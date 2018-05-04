using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PersonKartotek.Core.Repositories;

namespace PersonKartotek.Persistence.Repositories
{
    class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(KartotekContext context)
            : base(context)
        {
        }

        public Address GetCityWithAddresses(int id)
        {
            return KartotekContext.Addresses.Include(a => a.City).SingleOrDefault(a => a.AddressId == id);
        }

        public KartotekContext KartotekContext
        {
            get { return Context as KartotekContext; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PersonKartotek.Core.Domain;
using PersonKartotek.Core.Repositories;

namespace PersonKartotek.Persistence.Repositories
{
    class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(KartotekContext context)
            : base(context)
        {
        }

        public IEnumerable<Address> GetAddressesWithCity(int id)
        {
            return KartotekContext.Addresses
                .Where(c => c.City.CityId == id)
                .OrderBy(c => c.AddressId)
                .ToList();
        }

        public KartotekContext KartotekContext
        {
            get { return Context as KartotekContext; }
        }
    }
}

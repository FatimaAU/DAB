using System;
using System.Data.Entity;
using System.Linq;
using PersonKartotek.Core.Domain;
using PersonKartotek.Core.Repositories;

namespace PersonKartotek.Persistence.Repositories
{
    public class MainAdressRepository : Repository<MainAddress>, IMainAddressRepository
    {
        public MainAdressRepository(KartotekContext context) 
            : base(context)
        {
        }

        public MainAddress GetMainAddressWithPerson(int id)
        {
            Person p = KartotekContext.Persons
                .Include(a => a.Contact.MainAddress)
                .SingleOrDefault(a => a.PersonId == id);

            return KartotekContext.MainAddresses
                .FirstOrDefault(a => a.MainAddressId == p.Contact.MainAddress.MainAddressId);
        }

        public KartotekContext KartotekContext
        {
            get { return Context as KartotekContext; }
        }
    }
}
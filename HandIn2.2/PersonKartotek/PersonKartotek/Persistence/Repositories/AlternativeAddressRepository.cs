using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonKartotek.Core.Repositories;
using System.Data.Entity;
using PersonKartotek.Core.Domain;

namespace PersonKartotek.Persistence.Repositories
{
    public class AlternativeAddressRepository : Repository<AlternativeAddress>, IAlternativeAddressRepository
    {
        public AlternativeAddressRepository(KartotekContext context)
            : base(context)
        {
        }

        public AlternativeAddress GetAlternativeAddressWithContacts(string id)
        {
            Contact con = KartotekContext.Contacts.Where(c => c.Email == id);

            con.Email
            var person = KartotekContext.Persons.Include(a => a.Contact.Email)
                .SingleOrDefault(a => a.Contact.Email == id);

            return KartotekContext.MainAddresses.Where(b => b.)
            return KartotekContext.MainAddresses.Include(person.Contact.Email).SingleOrDefault(person.Contact.Email == id)
        }

        public KartotekContext KartotekContext
        {
            get { return Context as KartotekContext; }
        }
    }
}

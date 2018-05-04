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
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(KartotekContext context)
            : base(context)
        {
        }

        public Contact GetContactWithAlternativeAddresses(string email)
        {
            return KartotekContext.Contacts.Include(a => a.AlternativeAddresses).SingleOrDefault(a => a.Email == email);
        }

        public Contact GetContactWithMainAddress(string email)
        {
            return KartotekContext.Contacts.Include(a => a.MainAddress).SingleOrDefault(a => a.Email == email);
        }

        public Contact GetContactWithTelephones(string email)
        {
            return KartotekContext.Contacts.Include(a => a.Telephones).SingleOrDefault(a => a.Email == email);
        }

        public KartotekContext KartotekContext
        {
            get { return Context as KartotekContext; }
        }
    }
}

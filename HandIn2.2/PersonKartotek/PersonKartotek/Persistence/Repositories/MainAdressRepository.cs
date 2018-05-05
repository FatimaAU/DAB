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

        //public MainAddress GetMainAddressWithPerson(int id)
        //{
        //    Person p = KartotekContext.Persons.Find(id);

        //    Contact con = KartotekContext.Contacts.FirstOrDefault(c => c.Email == p.Contact.Email);

        //    return KartotekContext.MainAddresses.FirstOrDefault(cc => cc.Contacts.Contains(con));
        //}

        public MainAddress GetMainAddressWithPerson(int id)
        {
            Person p = KartotekContext.Persons
                .Include(a => a.Contact.MainAddress)
                .SingleOrDefault(a => a.PersonId == id);

            Contact con =  KartotekContext.Contacts
                //.Include(m => m.MainAddress)
                //.Include(a => a.MainAddress.Address)
                .FirstOrDefault(c => c.Email == p.Contact.Email);

            return KartotekContext.MainAddresses.FirstOrDefault(a => a.MainAddressId == con.MainAddress.MainAddressId);
        }

        public KartotekContext KartotekContext
        {
            get { return Context as KartotekContext; }
        }
    }
}
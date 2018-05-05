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

        //AlternativeAddress GetAlternativeAddressWithContacts(int id);
        //{

        //    return new AlternativeAddress(new Address());
        //    //return KartotekContext.S.FirstOrDefault(cc => cc.Contacts.Contains(con));
        //}

        public KartotekContext KartotekContext
        {
            get { return Context as KartotekContext; }
        }
    }
}

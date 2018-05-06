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

        public KartotekContext KartotekContext
        {
            get { return Context as KartotekContext; }
        }
    }
}

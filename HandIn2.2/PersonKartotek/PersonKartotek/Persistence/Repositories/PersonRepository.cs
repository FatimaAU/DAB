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
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(KartotekContext context)
            : base(context)
        {
        }

        public Person GetPersonWithContact(int id)
        {
            return KartotekContext.Persons.Include(a => a.Contact).SingleOrDefault(a => a.PersonId == id);
        }

        public KartotekContext KartotekContext
        {
            get { return Context as KartotekContext; }
        }
    }
}

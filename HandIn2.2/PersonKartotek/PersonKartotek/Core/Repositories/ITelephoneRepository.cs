using System.Collections.Generic;
using PersonKartotek.Core.Domain;

namespace PersonKartotek.Core.Repositories
{
    public interface ITelephoneRepository : IRepository<Telephone>
    {
        IEnumerable<Telephone> GetTelephonesWithTelecompany(string telecompany);
    }
}
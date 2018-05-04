using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonKartotek.Core.Domain;

namespace PersonKartotek.Core.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Contact GetContactWithAlternativeAddresses(string email);
        Contact GetContactWithMainAddress(string email);
        Contact GetContactWithTelephones(string email);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonKartotek.Core.Repositories
{
    public interface IContactRepository
    {
        Contact GetContactWithAlternativeAddresses(string id);
        Contact GetContactWithMainAddress(string email);
        Contact GetContactWithTelephones(string email);
    }
}

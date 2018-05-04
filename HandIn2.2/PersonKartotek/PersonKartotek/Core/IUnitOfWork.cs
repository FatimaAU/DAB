using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonKartotek.Persistence.Repositories;

namespace PersonKartotek.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAlternativeAddressRepository AlternativeAddress { get; }
        IAddressRepository Address { get; }
        IContactRepository Contact { get; }
        IPersonRepository Person { get; }
        int Complete();
    }
}

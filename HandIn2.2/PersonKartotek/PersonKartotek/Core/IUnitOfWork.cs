using System;
using PersonKartotek.Core.Repositories;

namespace PersonKartotek.Core
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

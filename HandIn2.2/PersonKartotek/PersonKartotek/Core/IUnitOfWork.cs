using System;
using PersonKartotek.Core.Domain;
using PersonKartotek.Core.Repositories;

namespace PersonKartotek.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAlternativeAddressRepository AlternativeAddress { get; }
        IAddressRepository Address { get; }
        IContactRepository Contact { get; }
        IPersonRepository Person { get; }
        IMainAddressRepository MainAddress { get; }
        int Complete();
    }
}

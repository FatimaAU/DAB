using PersonKartotek.Core.Domain;

namespace PersonKartotek.Core.Repositories
{
    public interface IMainAddressRepository : IRepository<MainAddress>
    {
        MainAddress GetMainAddressWithPerson(int id);
    }
}
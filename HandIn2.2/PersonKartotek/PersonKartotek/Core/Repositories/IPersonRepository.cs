using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonKartotek.Core.Domain;

namespace PersonKartotek.Core.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person GetPersonWithContact(int id);
    }
}

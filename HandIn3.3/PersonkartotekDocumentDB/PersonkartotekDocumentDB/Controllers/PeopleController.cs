using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PersonkartotekDocumentDB.Models;

namespace PersonkartotekDocumentDB.Controllers
{
    public class PeopleController : ApiController
    {
        public async Task<IEnumerable<Person>> GetPeople()
        {
            return await DocumentDBRepository<Person>.GetItemsAsync(p => true);
        }

        public async Task<IHttpActionResult> GetPerson(string id)
        {
            var person = await DocumentDBRepository<Person>.GetItemsAsync(p => p.Id == id);

            if (!person.Any())
                return NotFound();
            
            return Ok(person);
        }
    }
}

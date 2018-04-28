using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PersonkartotekDocumentDB.Models;

namespace PersonkartotekDocumentDB.Controllers
{
    public class PeopleController : ApiController
    {
        public async Task<IEnumerable<PersonSimpleDTO>> GetPeople()
        {
            return await DocumentDBRepository<PersonSimpleDTO>.Get(p => true);
        }

        [ResponseType(typeof(PersonDetailDTO))]
        public async Task<IHttpActionResult> GetPerson(string id)
        {
            var person = await DocumentDBRepository<PersonDetailDTO>.Get(p => p.Id == id);

            if (!person.Any())
                return NotFound();
            
            return Ok(person);
        }

        [ResponseType(typeof(PersonDetailDTO))]
        public async Task<IHttpActionResult> PutPerson(PersonDetailDTO person)
        {
            return await DocumentDBRepository<PersonDetailDTO>.Put(person);
        }

        [ResponseType(typeof(PersonDetailDTO))]
        public async Task<IHttpActionResult> PostPerson(PersonDetailDTO person)
        {
            return await DocumentDBRepository<PersonDetailDTO>.Post(person);
        }

        public async Task<IHttpActionResult> DeletePerson(string id)
        {
            return await DocumentDBRepository<PersonDetailDTO>.Delete(id);
        }



    }
}

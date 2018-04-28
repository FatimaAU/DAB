using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Handin3_2.Models;

namespace Handin3_2.Controllers
{
    public class PeopleController : ApiController
    {
        private Context db = new Context();

        // GET: api/People
        public IEnumerable<PeopleDTO> GetPeople()
        {
            var people = from b in db.People
                select new PeopleDTO()
                {
                    PersonId = b.PersonId,
                    Email = b.Contacts.Email,
                    FirstName = b.FirstName,
                    LastName = b.LastName,
                    MiddleName = b.MiddleName,
                };
            
            return people;
        }

        // GET: api/People/5
        [ResponseType(typeof(PeopleDetailDTO))]
        public async Task<IHttpActionResult> GetPeople(int id)
        {
            var people = await db.People.Include(b => b.Contacts).Select(b => new PeopleDetailDTO()
            {
                PersonId = b.PersonId,
                AddressType = b.Contacts.MainAddresses.Addresses.Type,
                CityName = b.Contacts.MainAddresses.Addresses.Cities.CityName,
                Country = b.Contacts.MainAddresses.Addresses.Country,
                Email = b.Contacts.Email,
                FirstName = b.FirstName,
                HouseNumber = b.Contacts.MainAddresses.Addresses.HouseNumber,
                LastName = b.LastName,
                MiddleName = b.MiddleName,
                StreetName = b.Contacts.MainAddresses.Addresses.StreetName,
                ZipCode = b.Contacts.MainAddresses.Addresses.Cities.ZipCode,
                AltAddresses = b.Contacts.AlternativeAddresses.Select(dt => new AddressesDTO()
                {
                    StreetName = dt.Addresses.StreetName,
                    CityName = dt.Addresses.Cities.CityName,
                    Country = dt.Addresses.Country,
                    HouseNumber = dt.Addresses.HouseNumber,
                    Type = dt.Addresses.Type,
                    ZipCode = dt.Addresses.Cities.ZipCode
                }),
                Telephones = b.Contacts.Telephones.Select(dt => new TelephonesDTO()
                {
                    TelephoneNumber = dt.Number,
                    TelephoneType = dt.Type,
                    TeleCompany = dt.TeleCompany
                })

            }).SingleOrDefaultAsync(b => b.PersonId == id);
            if (people == null)
            {
                return NotFound();
            }
            return Ok(people);
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPeople(int id, People people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != people.PersonId)
            {
                return BadRequest();
            }

            db.Entry(people).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/People
        [ResponseType(typeof(PeopleDetailDTO))]
        public async Task<IHttpActionResult> PostPeople(PeopleDetailDTO people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            People person = new People
            {
                PersonId = people.PersonId,
                FirstName = people.FirstName,
                LastName = people.LastName,
                MiddleName = people.MiddleName,
                Contacts = new Contacts
                {
                    Email = people.Email
                }
            };

            db.People.Add(person);
            await db.SaveChangesAsync();

            db.Entry(person).Reference(x => x.Contacts).Load();

            var dto = new PeopleDetailDTO
            {
                PersonId = people.PersonId,
                FirstName = people.FirstName,
                MiddleName = people.MiddleName,
                LastName = people.LastName,
                Email = people.Email,
                Telephones = people.Telephones,
                AltAddresses = people.AltAddresses,
                StreetName = people.StreetName,
                HouseNumber = people.HouseNumber,
                Country = people.Country,
                AddressType = people.AddressType,
                CityName = people.CityName,
                ZipCode = people.ZipCode

            };

            return CreatedAtRoute("DefaultApi", new { id = people.PersonId }, dto);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(People))]
        public IHttpActionResult DeletePeople(int id)
        {
            People people = db.People.Find(id);
            if (people == null)
            {
                return NotFound();
            }

            db.People.Remove(people);
            db.SaveChanges();

            return Ok(people);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PeopleExists(int id)
        {
            return db.People.Count(e => e.PersonId == id) > 0;
        }
    }
}
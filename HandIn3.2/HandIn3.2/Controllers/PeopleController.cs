using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HandIn3._2;
using HandIn3._2.Models;

namespace HandIn3._2.Controllers
{
    public class PeopleController : ApiController
    {
        private HandIn3_2Context db = new HandIn3_2Context();

        // GET: api/People
        public IQueryable<PeopleDTO> GetPeople()
        {
            var people = from b in db.People
                select new PeopleDTO()
                {
                    PersonId = b.PersonId,
                    //AddressType = b.Contacts.MainAddresses.Addresses.Type,
                    //CityName = b.Contacts.MainAddresses.Addresses.Cities.CityName,
                    //Country = b.Contacts.MainAddresses.Addresses.Country,
                    Email = b.Contacts.Email,
                    FirstName = b.FirstName,
                    //HouseNumber = b.Contacts.MainAddresses.Addresses.HouseNumber,
                    LastName = b.LastName,
                    MiddleName = b.MiddleName,
                    //TelephoneNumber = b.Contacts.Telephones.Number,
                    //StreetName = b.Contacts.MainAddresses.Addresses.StreetName,
                    //TeleCompany = b.Contacts.Telephones.TeleCompany,
                    //TelephoneType = b.Contacts.Telephones.Type,
                    //ZipCode = b.Contacts.MainAddresses.Addresses.Cities.ZipCode
                };
            return people;
        }

        // GET: api/People/5
        [ResponseType(typeof(People))]
        public IHttpActionResult GetPeople(int id)
        {
            People people = db.People.Find(id);
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
        [ResponseType(typeof(People))]
        public IHttpActionResult PostPeople(People people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.People.Add(people);
            db.SaveChanges();

            db.Entry(people).Reference(x => x.Contacts).Load();

            var dto = new PeopleDTO()
            {
                PersonId = people.PersonId,
                //AddressType = b.Contacts.MainAddresses.Addresses.Type,
                //CityName = b.Contacts.MainAddresses.Addresses.Cities.CityName,
                //Country = b.Contacts.MainAddresses.Addresses.Country,
                //Email = people.Contacts.Email,
                FirstName = people.FirstName,
                //HouseNumber = b.Contacts.MainAddresses.Addresses.HouseNumber,
                LastName = people.LastName,
                MiddleName = people.MiddleName
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
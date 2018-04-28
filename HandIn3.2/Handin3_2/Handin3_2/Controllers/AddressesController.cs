using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Handin3_2.Models;

namespace Handin3_2.Controllers
{
    public class AddressesController : ApiController
    {
        private Context db = new Context();

        // GET: api/Addresses
        public IQueryable<Addresses> GetAddresses()
        {
            return db.Addresses;
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(Addresses))]
        public IHttpActionResult GetAddresses(int id)
        {
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return NotFound();
            }

            return Ok(addresses);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddresses(int id, Addresses addresses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != addresses.AddressId)
            {
                return BadRequest();
            }

            db.Entry(addresses).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressesExists(id))
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

        // POST: api/Addresses
        [ResponseType(typeof(Addresses))]
        public IHttpActionResult PostAddresses(Addresses addresses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Addresses.Add(addresses);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = addresses.AddressId }, addresses);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Addresses))]
        public IHttpActionResult DeleteAddresses(int id)
        {
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(addresses);
            db.SaveChanges();

            return Ok(addresses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressesExists(int id)
        {
            return db.Addresses.Count(e => e.AddressId == id) > 0;
        }
    }
}
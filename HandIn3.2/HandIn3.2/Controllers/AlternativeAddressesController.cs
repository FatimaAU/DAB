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
using HandIn3._2;
using HandIn3._2.Models;

namespace HandIn3._2.Controllers
{
    public class AlternativeAddressesController : ApiController
    {
        private HandIn3_2Context db = new HandIn3_2Context();

        // GET: api/AlternativeAddresses
        public IQueryable<AlternativeAddresses> GetAlternativeAddresses()
        {
            return db.AlternativeAddresses;
        }

        // GET: api/AlternativeAddresses/5
        [ResponseType(typeof(AlternativeAddresses))]
        public IHttpActionResult GetAlternativeAddresses(int id)
        {
            AlternativeAddresses alternativeAddresses = db.AlternativeAddresses.Find(id);
            if (alternativeAddresses == null)
            {
                return NotFound();
            }

            return Ok(alternativeAddresses);
        }

        // PUT: api/AlternativeAddresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlternativeAddresses(int id, AlternativeAddresses alternativeAddresses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alternativeAddresses.AlternativeAddressId)
            {
                return BadRequest();
            }

            db.Entry(alternativeAddresses).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlternativeAddressesExists(id))
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

        // POST: api/AlternativeAddresses
        [ResponseType(typeof(AlternativeAddresses))]
        public IHttpActionResult PostAlternativeAddresses(AlternativeAddresses alternativeAddresses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AlternativeAddresses.Add(alternativeAddresses);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = alternativeAddresses.AlternativeAddressId }, alternativeAddresses);
        }

        // DELETE: api/AlternativeAddresses/5
        [ResponseType(typeof(AlternativeAddresses))]
        public IHttpActionResult DeleteAlternativeAddresses(int id)
        {
            AlternativeAddresses alternativeAddresses = db.AlternativeAddresses.Find(id);
            if (alternativeAddresses == null)
            {
                return NotFound();
            }

            db.AlternativeAddresses.Remove(alternativeAddresses);
            db.SaveChanges();

            return Ok(alternativeAddresses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlternativeAddressesExists(int id)
        {
            return db.AlternativeAddresses.Count(e => e.AlternativeAddressId == id) > 0;
        }
    }
}
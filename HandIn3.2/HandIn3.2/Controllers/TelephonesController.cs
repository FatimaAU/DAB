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
    public class TelephonesController : ApiController
    {
        private HandIn3_2Context db = new HandIn3_2Context();

        // GET: api/Telephones
        public IQueryable<Telephones> GetTelephones()
        {
            return db.Telephones;
        }

        // GET: api/Telephones/5
        [ResponseType(typeof(Telephones))]
        public IHttpActionResult GetTelephones(int id)
        {
            Telephones telephones = db.Telephones.Find(id);
            if (telephones == null)
            {
                return NotFound();
            }

            return Ok(telephones);
        }

        // PUT: api/Telephones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTelephones(int id, Telephones telephones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telephones.TelephoneId)
            {
                return BadRequest();
            }

            db.Entry(telephones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelephonesExists(id))
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

        // POST: api/Telephones
        [ResponseType(typeof(Telephones))]
        public IHttpActionResult PostTelephones(Telephones telephones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Telephones.Add(telephones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = telephones.TelephoneId }, telephones);
        }

        // DELETE: api/Telephones/5
        [ResponseType(typeof(Telephones))]
        public IHttpActionResult DeleteTelephones(int id)
        {
            Telephones telephones = db.Telephones.Find(id);
            if (telephones == null)
            {
                return NotFound();
            }

            db.Telephones.Remove(telephones);
            db.SaveChanges();

            return Ok(telephones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelephonesExists(int id)
        {
            return db.Telephones.Count(e => e.TelephoneId == id) > 0;
        }
    }
}
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
    public class MainAddressesController : ApiController
    {
        private HandIn3_2Context db = new HandIn3_2Context();

        // GET: api/MainAddresses
        public IQueryable<MainAddresses> GetMainAddresses()
        {
            return db.MainAddresses;
        }

        // GET: api/MainAddresses/5
        [ResponseType(typeof(MainAddresses))]
        public IHttpActionResult GetMainAddresses(int id)
        {
            MainAddresses mainAddresses = db.MainAddresses.Find(id);
            if (mainAddresses == null)
            {
                return NotFound();
            }

            return Ok(mainAddresses);
        }

        // PUT: api/MainAddresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMainAddresses(int id, MainAddresses mainAddresses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mainAddresses.MainAddressId)
            {
                return BadRequest();
            }

            db.Entry(mainAddresses).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainAddressesExists(id))
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

        // POST: api/MainAddresses
        [ResponseType(typeof(MainAddresses))]
        public IHttpActionResult PostMainAddresses(MainAddresses mainAddresses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MainAddresses.Add(mainAddresses);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mainAddresses.MainAddressId }, mainAddresses);
        }

        // DELETE: api/MainAddresses/5
        [ResponseType(typeof(MainAddresses))]
        public IHttpActionResult DeleteMainAddresses(int id)
        {
            MainAddresses mainAddresses = db.MainAddresses.Find(id);
            if (mainAddresses == null)
            {
                return NotFound();
            }

            db.MainAddresses.Remove(mainAddresses);
            db.SaveChanges();

            return Ok(mainAddresses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MainAddressesExists(int id)
        {
            return db.MainAddresses.Count(e => e.MainAddressId == id) > 0;
        }
    }
}
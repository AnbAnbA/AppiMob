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
using AppiMob.Models;

namespace AppiMob.Controllers
{
    public class OsoznMainsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/OsoznMains
        [ResponseType(typeof(List<OsoznMain>))]
        public IHttpActionResult GetOsoznMain()
        {
            return Ok(db.OsoznMain.ToList().ConvertAll(x=> new OsoznMainModel(x)));
        }

        // GET: api/OsoznMains/5
        [ResponseType(typeof(OsoznMain))]
        public IHttpActionResult GetOsoznMain(int id)
        {
            OsoznMain osoznMain = db.OsoznMain.Find(id);
            if (osoznMain == null)
            {
                return NotFound();
            }

            return Ok(osoznMain);
        }

        // PUT: api/OsoznMains/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOsoznMain(int id, OsoznMain osoznMain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != osoznMain.ID)
            {
                return BadRequest();
            }

            db.Entry(osoznMain).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OsoznMainExists(id))
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

        // POST: api/OsoznMains
        [ResponseType(typeof(OsoznMain))]
        public IHttpActionResult PostOsoznMain(OsoznMain osoznMain)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OsoznMain.Add(osoznMain);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OsoznMainExists(osoznMain.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = osoznMain.ID }, osoznMain);
        }

        // DELETE: api/OsoznMains/5
        [ResponseType(typeof(OsoznMain))]
        public IHttpActionResult DeleteOsoznMain(int id)
        {
            OsoznMain osoznMain = db.OsoznMain.Find(id);
            if (osoznMain == null)
            {
                return NotFound();
            }

            db.OsoznMain.Remove(osoznMain);
            db.SaveChanges();

            return Ok(osoznMain);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OsoznMainExists(int id)
        {
            return db.OsoznMain.Count(e => e.ID == id) > 0;
        }
    }
}
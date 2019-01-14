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
using EjemploJquery.Models;

namespace EjemploJquery.Controllers
{
    public class DocentesController : ApiController
    {
        private Modelo db = new Modelo();

        // GET: api/Docentes
        public IQueryable<Docentes> GetDocentes()
        {
            return db.Docentes;
        }

        // GET: api/Docentes/5
        [ResponseType(typeof(Docentes))]
        public IHttpActionResult GetDocentes(int id)
        {
            Docentes docentes = db.Docentes.Find(id);
            if (docentes == null)
            {
                return NotFound();
            }

            return Ok(docentes);
        }

        // PUT: api/Docentes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDocentes(int id, Docentes docentes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != docentes.Iddocente)
            {
                return BadRequest();
            }

            db.Entry(docentes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocentesExists(id))
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

        // POST: api/Docentes
        [ResponseType(typeof(Docentes))]
        public IHttpActionResult PostDocentes(Docentes docentes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Docentes.Add(docentes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = docentes.Iddocente }, docentes);
        }

        // DELETE: api/Docentes/5
        [ResponseType(typeof(Docentes))]
        public IHttpActionResult DeleteDocentes(int id)
        {
            Docentes docentes = db.Docentes.Find(id);
            if (docentes == null)
            {
                return NotFound();
            }

            db.Docentes.Remove(docentes);
            db.SaveChanges();

            return Ok(docentes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DocentesExists(int id)
        {
            return db.Docentes.Count(e => e.Iddocente == id) > 0;
        }
    }
}
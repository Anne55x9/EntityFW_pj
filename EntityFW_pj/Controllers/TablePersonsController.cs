using System;
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
using EntityFW_pj;

namespace EntityFW_pj.Controllers
{
    public class TablePersonsController : ApiController
    {
        private PjContext db = new PjContext();

        // GET: api/TablePersons
        public IQueryable<TablePerson> GetTablePersons()
        {
            return db.TablePersons;
        }

        // GET: api/TablePersons/5
        [ResponseType(typeof(TablePerson))]
        public async Task<IHttpActionResult> GetTablePerson(string id)
        {
            TablePerson tablePerson = await db.TablePersons.FindAsync(id);
            if (tablePerson == null)
            {
                return NotFound();
            }

            return Ok(tablePerson);
        }

        // PUT: api/TablePersons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTablePerson(string id, TablePerson tablePerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tablePerson.PersonCPR)
            {
                return BadRequest();
            }

            db.Entry(tablePerson).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TablePersonExists(id))
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

        // POST: api/TablePersons
        [ResponseType(typeof(TablePerson))]
        public async Task<IHttpActionResult> PostTablePerson(TablePerson tablePerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TablePersons.Add(tablePerson);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TablePersonExists(tablePerson.PersonCPR))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tablePerson.PersonCPR }, tablePerson);
        }

        // DELETE: api/TablePersons/5
        [ResponseType(typeof(TablePerson))]
        public async Task<IHttpActionResult> DeleteTablePerson(string id)
        {
            TablePerson tablePerson = await db.TablePersons.FindAsync(id);
            if (tablePerson == null)
            {
                return NotFound();
            }

            db.TablePersons.Remove(tablePerson);
            await db.SaveChangesAsync();

            return Ok(tablePerson);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TablePersonExists(string id)
        {
            return db.TablePersons.Count(e => e.PersonCPR == id) > 0;
        }
    }
}
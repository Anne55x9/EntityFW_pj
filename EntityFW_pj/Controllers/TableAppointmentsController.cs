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
    public class TableAppointmentsController : ApiController
    {
        private PjContext db = new PjContext();

        // GET: api/TableAppointments
        public IQueryable<TableAppointment> GetTableAppointments()
        {
            return db.TableAppointments;
        }

        // GET: api/TableAppointments/5
        [ResponseType(typeof(TableAppointment))]
        public async Task<IHttpActionResult> GetTableAppointment(int id)
        {
            TableAppointment tableAppointment = await db.TableAppointments.FindAsync(id);
            if (tableAppointment == null)
            {
                return NotFound();
            }

            return Ok(tableAppointment);
        }

        // PUT: api/TableAppointments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTableAppointment(int id, TableAppointment tableAppointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tableAppointment.AppointmentNo)
            {
                return BadRequest();
            }

            db.Entry(tableAppointment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableAppointmentExists(id))
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

        // POST: api/TableAppointments
        [ResponseType(typeof(TableAppointment))]
        public async Task<IHttpActionResult> PostTableAppointment(TableAppointment tableAppointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TableAppointments.Add(tableAppointment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tableAppointment.AppointmentNo }, tableAppointment);
        }

        // DELETE: api/TableAppointments/5
        [ResponseType(typeof(TableAppointment))]
        public async Task<IHttpActionResult> DeleteTableAppointment(int id)
        {
            TableAppointment tableAppointment = await db.TableAppointments.FindAsync(id);
            if (tableAppointment == null)
            {
                return NotFound();
            }

            db.TableAppointments.Remove(tableAppointment);
            await db.SaveChangesAsync();

            return Ok(tableAppointment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TableAppointmentExists(int id)
        {
            return db.TableAppointments.Count(e => e.AppointmentNo == id) > 0;
        }
    }
}
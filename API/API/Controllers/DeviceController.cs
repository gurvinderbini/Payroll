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
using API.Models;

namespace API.Controllers
{
    public class DeviceController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Device
        public IQueryable<Contacts> GetDbContact()
        {
            return db.DbContact;
        }


        // GET: api/Device/5
        [ResponseType(typeof(Contacts))]
        public IHttpActionResult GetContacts(int id)
        {
            Contacts contacts = db.DbContact.Find(id);
            if (contacts == null)
            {
                return NotFound();
            }

            return Ok(contacts);
        }


        // GET: api/Device/5
        [ResponseType(typeof(Contacts))]
        public IHttpActionResult GetContacts(string deviceId, string phoneNumber)
        {
            Contacts contacts = db.DbContact.FirstOrDefault(e => e.PhoneNumber == phoneNumber);
            if (contacts == null)
            {
                return NotFound();
            }

            if (contacts.DeviceID != deviceId)
            {
                contacts.DeviceID = deviceId;
                contacts.IsVarified = false;
                db.Entry(contacts).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Ok(contacts);
        }

        // PUT: api/Device/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContacts(int id, Contacts contacts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contacts.EntryID)
            {
                return BadRequest();
            }

            db.Entry(contacts).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactsExists(id))
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

        // POST: api/Device
        [ResponseType(typeof(Contacts))]
        public IHttpActionResult PostContacts(Contacts contacts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DbContact.Add(contacts);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contacts.EntryID }, contacts);
        }

        // DELETE: api/Device/5
        [ResponseType(typeof(Contacts))]
        public IHttpActionResult DeleteContacts(int id)
        {
            Contacts contacts = db.DbContact.Find(id);
            if (contacts == null)
            {
                return NotFound();
            }

            db.DbContact.Remove(contacts);
            db.SaveChanges();

            return Ok(contacts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactsExists(int id)
        {
            return db.DbContact.Count(e => e.EntryID == id) > 0;
        }
    }
}
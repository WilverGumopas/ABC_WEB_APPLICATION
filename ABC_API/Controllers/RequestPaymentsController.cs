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
using ABC_API.Models;

namespace ABC_API.Controllers
{
    public class RequestPaymentsController : ApiController
    {
        private ABC_DBEntities4 db = new ABC_DBEntities4();

        // GET: api/RequestPayments
        public IQueryable<RequestPayment> GetRequestPayments()
        {
            return db.RequestPayments;
        }

        // GET: api/RequestPayments/5
        [ResponseType(typeof(RequestPayment))]
        public IHttpActionResult GetRequestPayment(int id)
        {
            RequestPayment requestPayment = db.RequestPayments.Find(id);
            if (requestPayment == null)
            {
                return NotFound();
            }

            return Ok(requestPayment);
        }

        // PUT: api/RequestPayments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequestPayment(int id, RequestPayment requestPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requestPayment.Transaction_ID)
            {
                return BadRequest();
            }

            db.Entry(requestPayment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestPaymentExists(id))
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

        // POST: api/RequestPayments
        [ResponseType(typeof(RequestPayment))]
        public IHttpActionResult PostRequestPayment(RequestPayment requestPayment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestPayments.Add(requestPayment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = requestPayment.Transaction_ID }, requestPayment);
        }

        // DELETE: api/RequestPayments/5
        [ResponseType(typeof(RequestPayment))]
        public IHttpActionResult DeleteRequestPayment(int id)
        {
            RequestPayment requestPayment = db.RequestPayments.Find(id);
            if (requestPayment == null)
            {
                return NotFound();
            }

            db.RequestPayments.Remove(requestPayment);
            db.SaveChanges();

            return Ok(requestPayment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestPaymentExists(int id)
        {
            return db.RequestPayments.Count(e => e.Transaction_ID == id) > 0;
        }
    }
}
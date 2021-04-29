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
    public class RequestPListsController : ApiController
    {
        private ABC_DBEntities1 db = new ABC_DBEntities1();

        // GET: api/RequestPLists
        public IQueryable<RequestPaymentList> GetRequestPaymentLists()
        {
            return db.RequestPaymentLists;
        }

        // GET: api/RequestPLists/5
        [ResponseType(typeof(RequestPaymentList))]
        public IHttpActionResult GetRequestPaymentList(int id)
        {
            RequestPaymentList requestPaymentList = db.RequestPaymentLists.Find(id);
            if (requestPaymentList == null)
            {
                return NotFound();
            }

            return Ok(requestPaymentList);
        }

        // PUT: api/RequestPLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequestPaymentList(int id, RequestPaymentList requestPaymentList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requestPaymentList.Transaction_ID)
            {
                return BadRequest();
            }

            db.Entry(requestPaymentList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestPaymentListExists(id))
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

        // POST: api/RequestPLists
        [ResponseType(typeof(RequestPaymentList))]
        public IHttpActionResult PostRequestPaymentList(RequestPaymentList requestPaymentList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestPaymentLists.Add(requestPaymentList);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RequestPaymentListExists(requestPaymentList.Transaction_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = requestPaymentList.Transaction_ID }, requestPaymentList);
        }

        // DELETE: api/RequestPLists/5
        [ResponseType(typeof(RequestPaymentList))]
        public IHttpActionResult DeleteRequestPaymentList(int id)
        {
            RequestPaymentList requestPaymentList = db.RequestPaymentLists.Find(id);
            if (requestPaymentList == null)
            {
                return NotFound();
            }

            db.RequestPaymentLists.Remove(requestPaymentList);
            db.SaveChanges();

            return Ok(requestPaymentList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestPaymentListExists(int id)
        {
            return db.RequestPaymentLists.Count(e => e.Transaction_ID == id) > 0;
        }
    }
}
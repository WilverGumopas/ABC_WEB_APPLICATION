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
    public class BalancesController : ApiController
    {
        private ABC_DBEntities3 db = new ABC_DBEntities3();

        // GET: api/Balances
        public IQueryable<Balance> GetBalances()
        {
            return db.Balances;
        }

        // GET: api/Balances/5
        [ResponseType(typeof(Balance))]
        public IHttpActionResult GetBalance(int id)
        {
            Balance balance = db.Balances.Find(id);
            if (balance == null)
            {
                return NotFound();
            }

            return Ok(balance);
        }

        // PUT: api/Balances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBalance(int id, Balance balance)
        {
          
            if (id != balance.Balance_ID)
            {
                return BadRequest();
            }

            db.Entry(balance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BalanceExists(id))
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

        // POST: api/Balances
        [ResponseType(typeof(Balance))]
        public IHttpActionResult PostBalance(Balance balance)
        {
            

            db.Balances.Add(balance);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = balance.Balance_ID }, balance);
        }

        // DELETE: api/Balances/5
        [ResponseType(typeof(Balance))]
        public IHttpActionResult DeleteBalance(int id)
        {
            Balance balance = db.Balances.Find(id);
            if (balance == null)
            {
                return NotFound();
            }

            db.Balances.Remove(balance);
            db.SaveChanges();

            return Ok(balance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BalanceExists(int id)
        {
            return db.Balances.Count(e => e.Balance_ID == id) > 0;
        }
    }
}
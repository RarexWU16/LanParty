using LanParty.Core.Domain;
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

namespace LanParty.Web.API
{
    public class SeatsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Seats
        public IEnumerable<Seat> Get()
        {
            var seats = db.Seats;

            return seats;
        }

        // GET: api/Seats/5
        [ResponseType(typeof(Seat))]
        [Route("api/Seats/{id}")]
        public IHttpActionResult Get(Guid id)
        {
            List<Seat> seats = db.Seats
                .Where(x => x.Id == id).ToList();

            if (seats == null)
            {
                return NotFound();
            }

            return Ok(seats.First());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
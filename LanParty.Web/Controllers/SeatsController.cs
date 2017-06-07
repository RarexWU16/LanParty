using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LanParty.Core.Domain;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json.Serialization;

namespace LanParty.Web.Controllers
{
    public class SeatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // Boook
        public ActionResult Book(Guid seatId)
        {
            try
            {
                var seat = db.Seats.Find(seatId);
                var user = db.Users.Find(User.Identity.GetUserId());

                if (seat == null || user == null || seat.Reserved)
                {
                    return RedirectToAction("Index");
                }

                var newBooking = new Booking
                {
                    Id = Guid.NewGuid(),
                    Seat = db.Seats.Find(seatId),
                    UserId = User.Identity.GetUserId(),
                    BookingDate = DateTime.Now
                };

                db.Bookings.Add(newBooking);

                db.SaveChanges();

                return View("ConfirmBooking", newBooking);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Unbook(Guid seatId, Guid userId)
        {
            var unbook = db.Seats.Find(seatId);
            var user = db.Users.Find(userId.ToString());
            //var users = db.Users.Where(x => new Guid(x.Id) == userId).First();

            if (unbook == null)
            {
                return RedirectToAction("Index"); // TODO failzeEOrox
            }
            unbook.Reserved = false;

            try
            {
                db.Entry(unbook).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                // TODO failzeEOrox
            }

            //return RedirectToAction("Index");
            return RedirectToAction("DemoteToUser", "UsersAdmin", new { userId = userId.ToString() });
        }

        public ActionResult ConfirmBooking(Guid bookingId)
        {

            var confirmBooking = db.Bookings.Find(bookingId);
            if (confirmBooking == null || confirmBooking.Seat.Reserved)
            {
                return View(); // Todo ERORz
            }

            var user = db.Users.Find(User.Identity.GetUserId());

            var bookedSeat = db.Seats.Find(confirmBooking.Seat.Id);
            bookedSeat.Reserved = true;
            bookedSeat.User = user;
            bookedSeat.UserId = user.Id;

            try
            {
                db.Entry(bookedSeat).State = EntityState.Modified;

                db.Entry(bookedSeat.User).State = EntityState.Unchanged;

                db.SaveChanges();

                return RedirectToAction("ChangeRole", "UsersAdmin", new { userId = bookedSeat.User.Id });
            }
            catch (Exception)
            {
                return RedirectToAction("Index"); // TODO oo Erroz
            }

        }

        // GET: Seats
        public ActionResult Index()
        {

            //if (Request.IsAuthenticated && User.IsInRole("User"))
            //{
            //    var result = db.Bookings.Where(x => x.UserId == User.Identity.GetUserId() && x.Seat.Reserved == true);
            //}

            return View(db.Seats.ToList());
        }



        // GET: Seats/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = db.Seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(seat);
        }

        // GET: Seats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Position,PositionX,PositionY")] Seat seat)
        {
            if (ModelState.IsValid)
            {
                seat.Id = Guid.NewGuid();
                db.Seats.Add(seat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seat);
        }

        // GET: Seats/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = db.Seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(seat);
        }

        // POST: Seats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Position,PositionX,PositionY")] Seat seat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seat);
        }

        // GET: Seats/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seat seat = db.Seats.Find(id);
            if (seat == null)
            {
                return HttpNotFound();
            }
            return View(seat);
        }

        // POST: Seats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Seat seat = db.Seats.Find(id);
            db.Seats.Remove(seat);
            db.SaveChanges();
            return RedirectToAction("Index");
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

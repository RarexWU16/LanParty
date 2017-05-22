using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LanParty.Core.Domain;

namespace LanParty.Web.Controllers
{
    public class LansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lans
        public ActionResult Index()
        {
            return View(db.Lan.ToList());
        }

        // GET: Lans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lan lan = db.Lan.Find(id);
            if (lan == null)
            {
                return HttpNotFound();
            }
            return View(lan);
        }

        // GET: Lans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StartDate,EndDate,MaxParticipants,SocialMedia")] Lan lan)
        {
            if (ModelState.IsValid)
            {
                db.Lan.Add(lan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lan);
        }

        // GET: Lans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lan lan = db.Lan.Find(id);
            if (lan == null)
            {
                return HttpNotFound();
            }
            return View(lan);
        }

        // POST: Lans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartDate,EndDate,MaxParticipants,SocialMedia")] Lan lan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lan);
        }

        // GET: Lans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lan lan = db.Lan.Find(id);
            if (lan == null)
            {
                return HttpNotFound();
            }
            return View(lan);
        }

        // POST: Lans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lan lan = db.Lan.Find(id);
            db.Lan.Remove(lan);
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

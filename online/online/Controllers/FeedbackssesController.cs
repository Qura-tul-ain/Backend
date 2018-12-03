using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using online;

namespace online.Controllers
{
    public class FeedbackssesController : Controller
    {
        private onlineEntities2 db = new onlineEntities2();

        // GET: Feedbacksses
        public ActionResult Index()
        {
            var feedbacksses = db.Feedbacksses.Include(f => f.AspNetUser);
            return View(feedbacksses.ToList());
        }

        // GET: Feedbacksses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedbackss feedbackss = db.Feedbacksses.Find(id);
            if (feedbackss == null)
            {
                return HttpNotFound();
            }
            return View(feedbackss);
        }

        // GET: Feedbacksses/Create
        public ActionResult Create()
        {
            ViewBag.FK_ID = new SelectList(db.AspNetUsers, "Id", "Cnic");
            return View();
        }

        // POST: Feedbacksses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Subject,Description")] Feedbackss feedbackss)
        {
			Feedbackss fb = new Feedbackss();
			if (ModelState.IsValid)
            {
				
				fb.Description = feedbackss.Description;
				fb.Subject = feedbackss.Subject;
				fb.FK_ID = User.Identity.GetUserId();
				db.Feedbacksses.Add(fb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_ID = new SelectList(db.AspNetUsers, "Id", "Cnic", fb.FK_ID);
            return View(fb);
        }

        // GET: Feedbacksses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedbackss feedbackss = db.Feedbacksses.Find(id);
            if (feedbackss == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_ID = new SelectList(db.AspNetUsers, "Id", "Cnic", feedbackss.FK_ID);
            return View(feedbackss);
        }

        // POST: Feedbacksses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Subject,Description,FK_ID")] Feedbackss feedbackss)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedbackss).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_ID = new SelectList(db.AspNetUsers, "Id", "Cnic", feedbackss.FK_ID);
            return View(feedbackss);
        }

        // GET: Feedbacksses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedbackss feedbackss = db.Feedbacksses.Find(id);
            if (feedbackss == null)
            {
                return HttpNotFound();
            }
            return View(feedbackss);
        }

        // POST: Feedbacksses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedbackss feedbackss = db.Feedbacksses.Find(id);
            db.Feedbacksses.Remove(feedbackss);
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

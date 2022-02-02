using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Code_First_Jashim.Models;

namespace Code_First_Jashim.Controllers
{
    public class LiberiansController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        // GET: Liberians
        public ActionResult Index()
        {
            return View(db.Liberians.ToList());
        }

        // GET: Liberians/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liberian liberian = db.Liberians.Find(id);
            if (liberian == null)
            {
                return HttpNotFound();
            }
            return View(liberian);
        }

        // GET: Liberians/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Liberians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LiberianID,LiberianName")] Liberian liberian)
        {
            if (ModelState.IsValid)
            {
                db.Liberians.Add(liberian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(liberian);
        }

        // GET: Liberians/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liberian liberian = db.Liberians.Find(id);
            if (liberian == null)
            {
                return HttpNotFound();
            }
            return View(liberian);
        }

        // POST: Liberians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LiberianID,LiberianName")] Liberian liberian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(liberian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(liberian);
        }

        // GET: Liberians/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liberian liberian = db.Liberians.Find(id);
            if (liberian == null)
            {
                return HttpNotFound();
            }
            return View(liberian);
        }

        // POST: Liberians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Liberian liberian = db.Liberians.Find(id);
            db.Liberians.Remove(liberian);
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

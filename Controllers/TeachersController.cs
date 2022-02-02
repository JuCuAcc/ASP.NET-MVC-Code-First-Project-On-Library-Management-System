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
    public class TeachersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teachers
        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers teachers = db.Teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherID,TeacherName,Gender,PhoneNumber,Email")] Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teachers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teachers);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers teachers = db.Teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherID,TeacherName,Gender,PhoneNumber,Email")] Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teachers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teachers);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers teachers = db.Teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teachers teachers = db.Teachers.Find(id);
            db.Teachers.Remove(teachers);
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

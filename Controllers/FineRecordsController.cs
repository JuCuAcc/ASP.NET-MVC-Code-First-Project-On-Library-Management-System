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
    public class FineRecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FineRecords
        public ActionResult Index()
        {
            var fineRecords = db.FineRecords.Include(f => f.Members).Include(f => f.Students).Include(f => f.Teachers);
            return View(fineRecords.ToList());
        }

        // GET: FineRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FineRecords fineRecords = db.FineRecords.Find(id);
            if (fineRecords == null)
            {
                return HttpNotFound();
            }
            return View(fineRecords);
        }

        // GET: FineRecords/Create
        public ActionResult Create()
        {
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName");
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName");
            return View();
        }

        // POST: FineRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FineAmount,MemberID,StudentID,TeacherID")] FineRecords fineRecords)
        {
            if (ModelState.IsValid)
            {
                db.FineRecords.Add(fineRecords);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", fineRecords.MemberID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", fineRecords.StudentID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", fineRecords.TeacherID);
            return View(fineRecords);
        }

        // GET: FineRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FineRecords fineRecords = db.FineRecords.Find(id);
            if (fineRecords == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", fineRecords.MemberID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", fineRecords.StudentID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", fineRecords.TeacherID);
            return View(fineRecords);
        }

        // POST: FineRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FineAmount,MemberID,StudentID,TeacherID")] FineRecords fineRecords)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fineRecords).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", fineRecords.MemberID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", fineRecords.StudentID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "TeacherID", "TeacherName", fineRecords.TeacherID);
            return View(fineRecords);
        }

        // GET: FineRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FineRecords fineRecords = db.FineRecords.Find(id);
            if (fineRecords == null)
            {
                return HttpNotFound();
            }
            return View(fineRecords);
        }

        // POST: FineRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FineRecords fineRecords = db.FineRecords.Find(id);
            db.FineRecords.Remove(fineRecords);
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
